using System;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;

namespace EPiServer.Templates.Alloy.Business
{
    /// <summary>
    /// Provides extension methods for types intended to be used when working with page types
    /// </summary>
    public static class PageTypeExtensions
    {
        /// <summary>
        /// Returns the ID of the specified page type
        /// </summary>
        /// <param name="pageType">Any page type inheriting </param>
        /// <returns></returns>
        public static int GetPageTypeId(this Type pageType)
        {
            return pageType.GetPageType().ID;
        }

        /// <summary>
        /// Returns the definition for a specific page type
        /// </summary>
        /// <param name="pageType"></param>
        /// <returns></returns>
        public static PageType GetPageType(this Type pageType)
        {
            var pageTypeRepository = ServiceLocator.Current.GetInstance<PageTypeRepository>();

            return pageTypeRepository.Load(pageType);
        }
    }
}