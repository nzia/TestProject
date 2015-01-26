using System;
using System.Web;
using System.Web.UI.HtmlControls;
using EPiServer.Templates.Alloy.Models.Pages;

namespace EPiServer.Templates.Alloy.Views.MasterPages
{
    /// <summary>
    /// Base class for all master pages on the site
    /// </summary>
    /// <remarks></remarks>
    public abstract class SiteMasterPage : System.Web.UI.MasterPage
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            if (Master != null) // We only do this initialization for the top-level master page
            {
                return;
            }

            SetupMetaTags();
        }

        private void SetupMetaTags()
        {
            // Add keywords meta tag
            if (CurrentPage.MetaKeywords != null && CurrentPage.MetaKeywords.Length > 0)
            {
                Page.Header.Controls.Add(new HtmlMeta
                                             {
                                                 Name = "keywords",
                                                 Content = string.Join(",", CurrentPage.MetaKeywords)
                                             });
            }

            // Add description meta tag
            if (!string.IsNullOrWhiteSpace(CurrentPage.MetaDescription))
            {
                Page.Header.Controls.Add(new HtmlMeta
                {
                    Name = "description",
                    Content = CurrentPage.MetaDescription
                });
            }
        }

        /// <summary>
        /// Gets the current page
        /// </summary>
        protected SitePageData CurrentPage
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    throw new NotSupportedException("Unable to retrieve the current page without an HTTP context");
                }

                var pb = HttpContext.Current.Handler as PageBase;

                if (pb == null)
                {
                    throw new NotSupportedException("Unable to get the current PageBase object, unable to identify the current page");
                }

                var currentPage = pb.CurrentPage as SitePageData;

                if(currentPage == null)
                {
                    throw new NotSupportedException("The current page type does not inherit SitePageData");
                }

                return currentPage;
            }
        }
    }
}