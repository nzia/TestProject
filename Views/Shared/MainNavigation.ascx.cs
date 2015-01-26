using System;
using System.Configuration;
using EPiServer.Core;
using EPiServer.Templates.Alloy.Business;
using EPiServer.Templates.Alloy.Models.Pages;

namespace EPiServer.Templates.Alloy.Views.Shared
{
    /// <summary>
    /// Main navigation menu, normally rendered in the site header
    /// </summary>
    public partial class MainNavigation : SiteUserControlBase
    {
        /// <summary>
        /// Performs a search by redirecting to the search page
        /// </summary>
        protected void PerformSearch(object sender, EventArgs e)
        {
            var searchPageLink = PageReference.StartPage.GetPage<StartPage>().SearchPageLink;

            if (PageReference.IsNullOrEmpty(searchPageLink))
            {
                throw new ConfigurationErrorsException("No search page specified in site settings, please specify the 'Search Page' property on the start page");
            }

            var searchPageRedirectUrl = searchPageLink.GetPage().LinkURL;

            // Add query string parameter containing the search keywords to the search page's URL
            searchPageRedirectUrl = UriSupport.AddQueryString(searchPageRedirectUrl, "q", SearchKeywords.Text.Trim());

            Response.Redirect(searchPageRedirectUrl);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SearchKeywords.DataBind();

            HomePageLink.DataBind();
        }

        protected string GetThemeCssClass(object pageData)
        {
            return pageData is ICategorizable
                       ? string.Join(" ", ((ICategorizable) pageData).GetThemeCssClassNames())
                       : string.Empty;
        }
    }
}