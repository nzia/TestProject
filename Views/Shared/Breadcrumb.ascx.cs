using System;
using System.Linq;
using EPiServer.Core;

namespace EPiServer.Templates.Alloy.Views.Shared
{
    public partial class Breadcrumb : SiteUserControlBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Include all pages but the root page
            BreadcrumbList.DataSource = DataFactory.Instance.GetAncestors(CurrentPage.PageLink)
                                                            .Where(p => !p.ContentLink.CompareToIgnoreWorkID(PageReference.RootPage))
                                                            .Reverse();

            BreadcrumbList.DataBind();
        }
    }
}