using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.Security;
using EPiServer.Templates.Alloy.Business;
using EPiServer.Templates.Alloy.Business.WebControls;
using EPiServer.Web.WebControls;
using log4net;

namespace EPiServer.Templates.Alloy.Views.Shared
{
    /// <summary>
    /// Lists pages, commonly used for page list blocks, news lists and search results
    /// </summary>
    public partial class PageList : SiteUserControlBase
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(PageList));
        private List<PageData> _pagesToAppend;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            try
            {               
                SetupPageList();
            }
            catch (Exception ex)
            {
                _logger.ErrorFormat("Page list block could not be loaded: {0}", ex.Message);

                Controls.Clear();

                if (PrincipalInfo.HasAdminAccess) // Admins get a detailed error message
                {
                    Controls.Add(new TemplateHint { InnerText = string.Format("Page list could not be loaded: {0}", ex.Message) });

                    return;
                }

                if (PrincipalInfo.HasEditAccess) // Editors get a general error message
                {
                    Controls.Add(new TemplateHint { InnerText = "Page list could not be loaded." });
                }
            }
        }

        private void SetupPageList()
        {
            if (MaxCount > 0)
            {
                List.MaxCount = MaxCount;
            }

            // List pages beneath the specified list root
            if (!PageReference.IsNullOrEmpty(ListRoot))
            {
                if (Recursive)
                {
                    if (PageTypeFilter > 0)
                    {
                        List.DataSource = SiteDataFactory.Instance.FindPagesByPageType(ListRoot, List.MaxCount, true, PageTypeFilter);
                    }
                    else
                    {
                        List.DataSource = DataFactory.Instance.GetDescendents(ListRoot)
                                                              .Select(GetPage)
                                                              .ToArray(); // PageList does not support Where iterators for the DataSource property, so we pass our pages as an array
                    }
                }
                else
                {
                    if (PageTypeFilter > 0)
                    {
                        List.DataSource = DataFactory.Instance.GetChildren(ListRoot)
                                                              .Where(p => p.PageTypeID == PageTypeFilter)
                                                              .ToArray(); // PageList does not support Where iterators for the DataSource property, so we pass our pages as an array
                    }
                    else
                    {
                        List.PageLink = ListRoot;
                    }
                }
            }

            if (Pages == null)
            {
                return;
            }

            // Add any explicitly specified pages
            var pagesInList = List.DataSource as IEnumerable<PageData>;

            if (pagesInList == null)
            {
                List.DataSource = Pages.ToArray();     
            }
            else
            {
                var combinedListOfPages = pagesInList.ToList();

                combinedListOfPages.AddRange(Pages);

                List.DataSource = combinedListOfPages.ToArray();
            }

            List.DataBind();
        }

        protected void FilterPageList(object sender, FilterEventArgs e)
        {
            if (PageTypeFilter > 0) // Filter by page type
            {
                e.Pages.FilterByPageType(PageTypeFilter);
            }

            if (CategoryFilter != null && CategoryFilter.Any()) // Filter by category
            {
                e.Pages.FilterByCategories(CategoryFilter);
            }
        }

        /// <summary>
        /// Identifies if a content has a content link set.
        /// </summary>
        /// <remarks>
        /// Search hits for files will be wrapped as PageData with an empty content link.
        /// </remarks>
        protected bool HasContentLink(IContent content)
        {
            return content != null && !ContentReference.IsNullOrEmpty(content.ContentLink);
        }

        /// <summary>
        /// Gets or sets if pages' publish dates should be displayed
        /// </summary>
        public bool IncludePublishDate { get; set; }

        /// <summary>
        /// Gets or sets if page description text should be displayed
        /// </summary>
        public bool IncludeIntroduction { get; set; }

        /// <summary>
        /// Gets or sets if page searches should be recursive or just include the first level beneath the list root
        /// </summary>
        public bool Recursive { get; set; }

        /// <summary>
        /// Gets or sets the list root, pages beneath this page will be included in the list
        /// </summary>
        public PageReference ListRoot { get; set; }
        
        /// <summary>
        /// Gets or sets maximum number of pages to include in list, 0 = include all
        /// </summary>
        public int MaxCount { get; set; }

        /// <summary>
        /// Gets or sets ID of page type to filter by, 0 = no filter
        /// </summary>
        public int PageTypeFilter { get; set; }

        /// <summary>
        /// Gets or sets categories to filter by, if any
        /// </summary>
        /// <remarks>If more than one category is specified, pages matching one or more of these categories will be included in the list</remarks>
        public CategoryList CategoryFilter { get; set; }

        /// <summary>
        /// Gets or sets the sort order for the page list
        /// </summary>
        public FilterSortOrder SortOrder
        {
            get { return List.SortOrder; }
            set { List.SortOrder = value; }
        }

        /// <summary>
        /// Gets or sets a data source serving additional pages to append to the page list
        /// </summary>
        /// <remarks>Can be used in combination with setting a ListRoot</remarks>
        public IDataSourceMethods DataSource { get; set; }

        /// <summary>
        /// Gets any pages from the specified DataSource
        /// </summary>
        public IEnumerable<PageData> Pages
        {
            get
            {
                if (DataSource == null)
                {
                    return new PageData[0];
                }

                return _pagesToAppend
                        ?? (_pagesToAppend = (DataSource.Select(new DataSourceSelectArguments()) as IEnumerable<PageData> 
                        ?? new PageData[0]).ToList());
            }
        }
    }
}
