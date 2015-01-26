using System;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Templates.Alloy.Models.Blocks;
using EPiServer.Web;

namespace EPiServer.Templates.Alloy.Views.Blocks
{
    [TemplateDescriptor(
        AvailableWithoutTag = false,
        Tags = new [] { Global.ContentAreaTags.FullWidth })] // Only allowed in full-width content areas
    public partial class JumbotronBlockControl : SiteBlockControlBase<JumbotronBlock>
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            jumboLink.DataBind();

            // In on-page edit mode, clicking the link button should allow editor to edit the link button text
            jumboLink.ApplyEditAttributes<JumbotronBlock>(b => b.JumbotronButtonText);
        }

        /// <summary>
        /// Gets the minimum width of a Jumbotron block
        /// </summary>
        public override int MinimumWidth
        {
            get
            {
                return Global.ContentAreaWidths.FullWidth;
            }
            set
            {
                throw new NotSupportedException("Minimum width cannot be modified for Jumbotron blocks");
            }
        }
    }
}