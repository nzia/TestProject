using System;
using EPiServer.Templates.Alloy.Models.Blocks;
using EPiServer.Web;
using log4net;

namespace EPiServer.Templates.Alloy.Views.Blocks
{
    /// <summary>
    /// Primarily used to display contact details in a contact block
    /// </summary>
    public partial class ContactBlockControl : SiteBlockControlBase<ContactBlock>
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof (ContactBlockControl));

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Only display the button if a link URL and link text have been specified
            ContactBlockLink.Visible = !string.IsNullOrWhiteSpace(CurrentBlock.ContactBlockLinkText) &&
                                       CurrentBlock.ContactBlockLinkUrl != null &&
                                       !CurrentBlock.ContactBlockLinkUrl.IsEmpty();

            // In edit mode an editor can click the link button below the contact details to edit its text
            Link.ApplyEditAttributes<ContactBlock>(c => c.ContactBlockLinkText);

            Link.DataBind();
        }
    }
}