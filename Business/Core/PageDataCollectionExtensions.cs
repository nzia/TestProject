using System;
using System.Linq;
using EPiServer.Core;

namespace EPiServer.Templates.Alloy.Business
{
    /// <summary>
    /// Provides extension methods for <see cref="PageDataCollection"/> objects, for example to filter by page type
    /// </summary>
    public static class PageDataCollectionExtensions
    {
        /// <summary>
        /// Removes any page not of the specified type from the page collection
        /// </summary>
        /// <param name="pages">The page collection to filter</param>
        /// <param name="pageType">The type of pages that should be left in the page collection</param>
        public static void FilterByPageType(this PageDataCollection pages, Type pageType)
        {
            var pageTypeId = pageType.GetPageTypeId();

            pages.FilterByPageType(pageTypeId);
        }

        /// <summary>
        /// Removes any page not of the specified type from the page collection
        /// </summary>
        /// <param name="pages">The page collection to filter</param>
        /// <param name="pageTypeId">Page type ID of pages that should be left in the page collection</param>
        public static void FilterByPageType(this PageDataCollection pages, int pageTypeId)
        {
            for (var i = pages.Count - 1; i >= 0; i--)
            {
                if (pages[i].PageTypeID != pageTypeId)
                {
                    pages.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Removes any page not matching any of the specified categories
        /// </summary>
        /// <param name="pages">The page collection to filter</param>
        /// <param name="categories">Categories used for filtering, pages not matching at least one category will be filtered out</param>
        public static void FilterByCategories(this PageDataCollection pages, CategoryList categories)
        {
            if (categories == null || !categories.Any())
            {
                return;
            }

            for (var i = pages.Count - 1; i >= 0; i--)
            {
                var atLeastOneCategoryMatches = categories.Any(c => pages[i].Category.Contains(c));

                if (!atLeastOneCategoryMatches)
                {
                    pages.RemoveAt(i);
                }
            }
        }
    }
}