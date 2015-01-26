using System;
using EPiServer.Filters;
using EPiServer.Templates.Alloy.Models.Blocks;
using EPiServer.Web;
using log4net;

namespace EPiServer.Templates.Alloy.Views.Blocks
{
    public partial class PageListBlockControl : SiteBlockControlBase<PageListBlock>
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof (PageListBlockControl));

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Configure page list based on block properties
            PageList.CategoryFilter = CurrentBlock.PageListCategoryFilter;
            PageList.IncludeIntroduction = CurrentBlock.PageListIncludeIntroduction;
            PageList.IncludePublishDate = CurrentBlock.PageListIncludePublishDate;
            PageList.ListRoot = CurrentBlock.PageListRoot;
            PageList.MaxCount = CurrentBlock.PageListCount;
            PageList.PageTypeFilter = CurrentBlock.PageListPageTypeFilter != null ? CurrentBlock.PageListPageTypeFilter.ID : 0;
            PageList.Recursive = CurrentBlock.PageListRecursive;
            PageList.SortOrder = (FilterSortOrder)CurrentBlock.PageListSortOrder;
        }
    }
}