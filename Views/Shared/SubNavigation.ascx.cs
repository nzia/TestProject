using System.Linq;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Templates.Alloy.Business;

namespace EPiServer.Templates.Alloy.Views.Shared
{
    /// <summary>
    /// Sub navigation menu, mainly for standard pages with a menu on the left-hand side
    /// </summary>
    public partial class SubNavigation : SiteUserControlBase
    {
        protected PageReference TopPageLink
        {
            get { return CurrentPage.PageLink.GetTopPage(); }
        }

        /// <summary>
        /// Checks if the specified page has any children that should be visible in the menu
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        protected bool HasChildren(object page)
        {
            if (!(page is PageData))
            {
                return false;
            }

            var children = DataFactory.Instance.GetChildren(((PageData) page).PageLink);

            return FilterForVisitor.Filter(children).Any(p => p.IsVisibleOnSite() && p.VisibleInMenu);
        }
    }
}
