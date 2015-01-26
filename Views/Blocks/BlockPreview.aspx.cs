using System;
using System.Collections.Generic;
using System.Web;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Security;
using EPiServer.SpecializedProperties;
using EPiServer.Templates.Alloy.Business;
using EPiServer.Web;
using EPiServer.Web.Routing;
using EPiServer.Web.WebControls;
using log4net;

namespace EPiServer.Templates.Alloy.Views.Blocks
{
    /// <summary>
    /// Template used to preview a block using a generic rendering
    /// </summary>
    [TemplateDescriptor(Inherited = true, Tags = new[] { RenderingTags.Preview })]
    public partial class BlockPreview : PreviewPage, IRenderTemplate<BlockData>
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            RenderBlockPreviews();
        }

        protected override void OnSaveStateComplete(EventArgs e)
        {
            base.OnSaveStateComplete(e);

            // We use data-binding expressions for setting hint messages visibility
            TwoThirdsWidthPreviewPropertyHint.DataBind();
            HalfWidthPreviewPropertyHint.DataBind();
            OneThirdWidthPreviewPropertyHint.DataBind();
        }

        private void RenderBlockPreviews()
        {
            // Set up property controls for block previews

            SetupPreviewPropertyControl(FullWidthPreviewProperty, new [] { CurrentData });
            SetupPreviewPropertyControl(TwoThirdsWidthPreviewProperty, new[] { CurrentData });
            SetupPreviewPropertyControl(HalfWidthPreviewProperty, new[] { CurrentData });
            SetupPreviewPropertyControl(OneThirdWidthPreviewProperty, new[] { CurrentData });
        }

        /// <summary>
        /// Sets up a Property control to render contents using temporary property data
        /// </summary>
        /// <param name="propertyControl"></param>
        /// <param name="contents"></param>
        private void SetupPreviewPropertyControl(Property propertyControl, IEnumerable<IContent> contents)
        {
            // Define a content area
            var contentArea = new ContentArea();

            // Add the blocks to preview
            foreach (var content in contents)
            {
                contentArea.Add(content);
            }
            
            // Create a temporary property for the content area
            var previewProperty = new PropertyContentArea {Value = contentArea, Name = "PreviewPropertyData"};

            // Render the temporary property using the Property control in the web form
            propertyControl.InnerProperty = previewProperty;
        }      
    }
}
