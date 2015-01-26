using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.ServiceLocation;
using EPiServer.Templates.Alloy.Models.Pages;

namespace EPiServer.Templates.Alloy.Business
{
     /// <summary>
    /// Used for common content actions
    /// </summary>   
    public sealed class SiteDataFactory
    {
        private static readonly SiteDataFactory _instance = new SiteDataFactory();

        private SiteDataFactory() { }

        public static SiteDataFactory Instance
        {
            get
            {
                return _instance;
            }
        }

        /// <summary>
        /// Returns all contact pages beneath the main contacts container
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ContactPage> GetContactPages()
        {
            var contactsRootPageLink = PageReference.StartPage.GetPage<StartPage>().ContactsPageLink;

            if (PageReference.IsNullOrEmpty(contactsRootPageLink))
            {
                throw new ConfigurationErrorsException("No contact page root specified in site settings, unable to retrieve contact pages");
            }

            return DataFactory.Instance.GetChildren<ContactPage>(contactsRootPageLink).OrderBy(p => p.PageName);
        }

        /// <summary>
        /// Returns pages of a specific page type
        /// </summary>
        /// <typeparam name="TPageData">The page type to filter by</typeparam>
        /// <param name="pageLink"></param>
        /// <param name="maxCount"></param>
        /// <param name="recursive"></param>
        /// <returns></returns>
        public IEnumerable<TPageData> FindPagesByPageType<TPageData>(PageReference pageLink, int maxCount, bool recursive) where TPageData : SitePageData
        {
            if (PageReference.IsNullOrEmpty(pageLink))
            {
                throw new ArgumentNullException("pageLink", "No page link specified, unable to find pages");
            }

            if (maxCount < 1)
            {
                throw new ArgumentOutOfRangeException("maxCount", "A positive integer is required");
            }

            var pages = recursive
                        ? FindPagesByPageTypeRecursively<TPageData>(pageLink)
                        : DataFactory.Instance.GetChildren<TPageData>(pageLink);

            return pages.Take(maxCount).ToArray(); // We return it as an array to allow databinding to a PageList control's DataSource property
        }

        /// <summary>
        /// Returns pages of a specific page type
        /// </summary>
        /// <param name="pageLink"></param>
        /// <param name="maxCount"></param>
        /// <param name="recursive"></param>
        /// <param name="pageTypeId">ID of the page type to filter by</param>
        /// <returns></returns>
        public IEnumerable<PageData> FindPagesByPageType(PageReference pageLink, int maxCount, bool recursive, int pageTypeId)
        {
            if (PageReference.IsNullOrEmpty(pageLink))
            {
                throw new ArgumentNullException("pageLink", "No page link specified, unable to find pages");
            }

            if (maxCount < 1)
            {
                throw new ArgumentOutOfRangeException("maxCount", "A positive integer is required");
            }

            var pages = recursive
                        ? FindPagesByPageTypeRecursively(pageLink, pageTypeId)
                        : DataFactory.Instance.GetChildren(pageLink);

            return pages.Take(maxCount).ToArray(); // We return it as an array to allow databinding to a PageList control's DataSource property
        }

        // Type specified through generic type parameter
        private IEnumerable<TPageData> FindPagesByPageTypeRecursively<TPageData>(PageReference pageLink) where TPageData : SitePageData
        {
            var pageTypeId = typeof(TPageData).GetPageTypeId();

            var pages = FindPagesByPageTypeRecursively(pageLink, pageTypeId);

            return pages.Select(p => (TPageData)p);
        }

        // Type specified through page type ID
        private IEnumerable<PageData> FindPagesByPageTypeRecursively(PageReference pageLink, int pageTypeId)
        {
            var criteria = new PropertyCriteriaCollection
                               {
                                    new PropertyCriteria
                                    {
                                        Name = "PageTypeID",
                                        Type = PropertyDataType.PageType,
                                        Condition = CompareCondition.Equal,
                                        Value = pageTypeId.ToString()
                                    }
                               };

            // Include content providers serving content beneath the page link specified for the search
            var providerManager = ServiceLocator.Current.GetInstance<IContentProviderManager>();
            
            if(providerManager.ProviderMap.CustomProvidersExist)
            {
                var contentProvider = providerManager.ProviderMap.GetProvider(pageLink);

                if (contentProvider.HasCapability(PageProviderCapabilities.Search))
                {
                    criteria.Add(new PropertyCriteria
                                     {
                                         Name = "EPI:MultipleSearch",
                                         Value = contentProvider.ProviderKey
                                     });
                }
            }

            return DataFactory.Instance.FindPagesWithCriteria(pageLink, criteria);
        }
    }
}