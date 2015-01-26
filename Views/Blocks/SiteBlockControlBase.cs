using EPiServer.Templates.Alloy.Business.WebControls;
using EPiServer.Templates.Alloy.Models.Blocks;
using EPiServer.Web;
using log4net;

namespace EPiServer.Templates.Alloy.Views.Blocks
{
    /// <summary>
    /// Base class for controls used to render blocks
    /// </summary>
    /// <typeparam name="T">Block type inheriting SiteBlockData</typeparam>
    public class SiteBlockControlBase<T> : BlockControlBase<T>, IBlockControl<T> where T : SiteBlockData
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof (SiteBlockControlBase<T>));
        private int _width, _minimumWidth, _maximumWidth;

        public SiteBlockControlBase()
        {
            EnableViewState = false;
        }

        /// <summary>
        /// Gets or sets a CSS class for this block's rendering container
        /// </summary>
        public virtual string ContainerCssClass { get; set; }

        /// <summary>
        /// Gets or sets the minimum width required by the block control to aid in block rendering
        /// </summary>
        public virtual int MinimumWidth
        {
            get
            {
                return _minimumWidth != 0 ? _maximumWidth : 4; // Default to 4 (one third width)
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