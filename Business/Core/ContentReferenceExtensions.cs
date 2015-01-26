using System;
using EPiServer.Core;

namespace EPiServer.Templates.Alloy.Business
{
    /// <summary>
    /// Provides extension methods for content references
    /// </summary>
    public static class ContentReferenceExtensions
    {
        /// <summary>
        /// Gets the top page reference, i e page beneath the start page, starting at the specified page reference
        /// </summary>
        public static PageReference GetTopPage(this PageReference pageLink)
        {
            if (PageReference.IsNullOrEmpty(pageLink))
            {
                throw new NotSupportedException("Current top page cannot be retrieved without a starting point, and the specified page link was empty");
            }

            var page = pageLink.GetPage();

            while (!PageReference.IsNullOrEmpty(page.ParentLink) && !page.ParentLink.CompareToIgnoreWorkID(PageReference.RootPage) && !page.ParentLink.CompareToIgnoreWorkID(PageReference.StartPage))
            {
                page = page.ParentLink.GetPage();
            }

            return page.PageLink;
        }

        /// <summary>
        /// Shorthand for DataFactory.Instance.GetPage
        /// </summary>
        public static PageData GetPage(this PageReference pageLink)
        {
            return DataFactory.Instance.GetPage(pageLink);
        }

        /// <summary>
        /// Shorthand for DataFactory.Instance.GetPage
        /// </summary>
        public static T GetPage<T>(this PageReference pageLink) where T : PageData
        {
            if (pageLink.CompareToIgnoreWorkID(PageReference.RootPage))
            {
                throw new NotSupportedException("The root page cannot be converted to type " + typeof(T).Name);
            }

            return (T)DataFactory.Instance.GetPage(pageLink);
        }

        /// <summary>
        /// Shorthand for DataFactory.Instance.GetPage
        /// </summary>
        public static PageData GetPage(this PageReference pageLink, ILanguageSelector languageSelector)
        {
            return DataFactory.Instance.GetPage(pageLink, languageSelector);
        }

    }
}