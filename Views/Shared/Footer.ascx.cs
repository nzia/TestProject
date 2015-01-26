using System;
using System.Web.Security;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Templates.Alloy.Business;
using EPiServer.Templates.Alloy.Models.Pages;

namespace EPiServer.Templates.Alloy.Views.Shared
{
    public partial class Footer : SiteUserControlBase
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            StartPage = PageReference.StartPage.GetPage<StartPage>();

            CustomerZone.DataBind();
        }

        /// <summary>
        /// Filters out all but product pages
        /// </summary>
        protected void FilterProductPages(object sender, FilterEventArgs e)
        {
            e.Pages.FilterByPageType(typeof (ProductPage));
        }

        /// <summary>
        /// Gets the start page
        /// </summary>
        protected StartPage StartPage { get; private set; }

        protected void Logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Response.Redirect(CurrentPage.LinkURL); // To have the page reload without the authentication cookie, causing the "Log in" link to re-appear
        }
    }
}