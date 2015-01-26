using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPiServer.Web;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Templates.Alloy.Models.Pages;
using EPiServer.Templates.Alloy.Business;

namespace EPiServer.Templates.Alloy.Views.Properties
{
    [TemplateDescriptor(TagString = "ContactBlock")]
    public partial class ContactDetailsByPageReference : PropertyControlBase<PageReference>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!PageReference.IsNullOrEmpty(CurrentData))
            {
                Contact = CurrentData.GetPage() as ContactPage;
                DataBind();
            }
        }

        /// <summary>
        /// Gets the contact page linked to this block
        /// </summary>
        protected ContactPage Contact { get; private set; }

        protected string Email { get { return Contact != null ? Contact.Email : "N/A"; } }
        protected string ImageUrl { get { return Contact != null ? Contact.Image.ToString() : ""; } }
        protected string ContactName { get { return Contact != null ? Contact.PageName : "No contact selected"; } }
        protected string Phone { get { return Contact != null ? Contact.Phone : "N/A"; } }
    }
}