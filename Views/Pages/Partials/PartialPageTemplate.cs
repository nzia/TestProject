using System;
using EPiServer.Templates.Alloy.Business.WebControls;
using EPiServer.Templates.Alloy.Models.Pages;
using EPiServer.Web;

namespace EPiServer.Templates.Alloy.Views.Pages.Partials
{
    /// <summary>
    /// Base class for user controls used to render pages when dropped in a content area
    /// </summary>
    /// <typeparam name="T">Any page type inheriting from SitePageData</typeparam>
    public abstract class PartialPageTemplate<T> : ContentControlBase<SitePageData, T>, IBlockControl<T> where T : SitePageData
    {
        private int _width, _minimumWidth, _maximumWidth;

        /// <summary>
        /// Gets or sets a CSS class for this partial view's rendering container
        /// </summary>
        public virtual string ContainerCssClass { get; set; }

        /// <summary>
        /// Gets or sets the minimum width required by the block control to aid in block rendering
        /// </summary>
        public virtual int MinimumWidth
        {
            get
            {
                return _minimumWidth != 0 ? _minimumWidth : 4; // Default to 4 (one third width)
            }
            set
            {
                _minimumWidth = value;

                this.ThrowIfInvalidMinimumWidth();
            }
        }

        /// <summary>
        /// Gets or sets the maximum width offered by the block control to aid in block rendering
        /// </summary>
        public virtual int MaximumWidth
        {
            get
            {
                return _maximumWidth != 0 ? _maximumWidth : 12; // Default to 12 (full width)
            }
            set
            {
                _maximumWidth = value;

                this.ThrowIfInvalidMaximumWidth();
            }
        }

        /// <summary>
        /// Gets or sets the width of which to render the block control, for example 4 for "span4"
        /// </summary>
        public int Width
        {
            get
            {
                return _width != 0 ? _width : MaximumWidth; // Default to maximum width
            }
            set
            {
                _width = value;

                this.ThrowIfInvalidWidth();
            }
        }
    }
}
