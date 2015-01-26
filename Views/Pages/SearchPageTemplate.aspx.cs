using System;
using System.Globalization;
using System.Linq;
using EPiServer.Core;
using EPiServer.Globalization;
using EPiServer.Search;
using EPiServer.Templates.Alloy.Business.WebControls;
using EPiServer.Templates.Alloy.Models.Pages;
using EPiServer.Web.WebControls;

namespace EPiServer.Templates.Alloy.Views.Pages
{
    /// <summary>
    /// Presents a page used to search the website using EPiServer's built-in standard search features
    /// </summary>
    public partial class SearchPageTemplate : SiteTemplatePage<SearchPage>
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!SearchSettings.Config.Active)
            {
                SearchResultPlaceHolder.Controls.Clear();

                SearchResultPlaceHolder.Controls.Add(new TemplateHint { InnerText = Translate("/searchpagetemplate/disabled") });

                SearchResultPlaceHolder.Visible = true;

                return;
            }

            SearchResult.DataSource = SearchDataSource;
        }

        /// <summary>
        /// When the page is loaded a search is carried out based on the 'q' query string parameter
        /// </summary>
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack) // Searches are performed by a page load with a 'q' querystring parameter, not through postback
            {
                var query = Request.QueryString["q"];

                if (!String.IsNullOrEmpty(query))
                {
                    SearchKeywords.Text = query;

                    // Configure search options
                    if (SearchSettings.Config.Active)
                    {
                        SearchDataSource.PageLink = PageReference.StartPage; // Search within the current site
                        SearchDataSource.LanguageBranches = ContentLanguage.PreferredCulture.Name;
                        SearchDataSource.SearchLocations = "~/Global/,~/Documents/,~/PageFiles/"; // TODO Get VPP providers from config instead?
                        SearchDataSource.Selected += HandleErrors;

                        DisplaySearchResult();   
                    }
                }
            }

            // Databind for translations
            SearchButton.DataBind();
        }

        /// <summary>
        /// When search button is clicked, we reload the page to trigger a new search
        /// </summary>
        protected void SearchClick(object sender, EventArgs e)
        {
            Response.Redirect(UriSupport.AddQueryString(CurrentPage.LinkURL, "q", SearchKeywords.Text.Trim()));
        }

        private void DisplaySearchResult()
        {
            var numberOfHits = SearchResult.Pages.Count();

            SearchResultSummaryPlaceHolder.Visible = true;
            
            SearchResultPlaceHolder.Visible = numberOfHits > 0;

            NumberOfHits.Text = numberOfHits == 0
                                ? Translate("/searchpagetemplate/zero")
                                : numberOfHits.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// This method looks for exceptions in the DataSourceStatusEventArgs parameter and invalidates a validator with the corresponding exception message
        /// </summary>
        protected void HandleErrors(object sender, DataSourceStatusEventArgs e)
        {
            if (e.Exception == null)
            {
                return;
            }

            SearchKeywordsValidator.ErrorMessage = e.Exception.Message;
            SearchKeywordsValidator.Text = e.Exception.Message;
            SearchKeywordsValidator.IsValid = false;
            e.ExceptionHandled = true;
        }
    }
}
