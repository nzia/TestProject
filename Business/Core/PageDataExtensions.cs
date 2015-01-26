using EPiServer.Core;

namespace EPiServer.Templates.Alloy.Business
{
    /// <summary>
    /// Extension methods for pages
    /// </summary>
    public static class PageDataExtensions
    {
        /// <summary>
        /// Checks if a specific page is located beneath another page
        /// </summary>
        public static bool IsDescendantOf(this PageData page, PageData parent)
        {
            while (!PageReference.IsNullOrEmpty(page.ParentLink))
            {
                if (page.ParentLink.CompareToIgnoreWorkID(parent.PageLink))
                {
                    return true;
                }

                page = page.ParentLink.GetPage();
            }

            return false;
        }

        /// <summary>
        /// Gets the top page, i e page beneath the start page, starting at the specified page
        /// </summary>
        public static PageReference GetTopPage(this PageData page)
        {
            return page.PageLink.GetTopPage();
        }
    }
}