using System;
using System.Text;
using EPiServer.Framework.Localization;
using EPiServer.Globalization;
using EPiServer.Web;
using EPiServer.XForms.WebControls;
using Label = System.Web.UI.WebControls.Label;

namespace EPiServer.Templates.Alloy
{
    public class Global : EPiServer.Global
    {
        protected void Application_Start(Object sender, EventArgs e)
        {
            XFormControl.ControlSetup += new EventHandler(XForm_ControlSetup);
        }

        #region Global XForm Events

        /// <summary>
        /// Sets up events for each new instance of the XFormControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks>As the ControlSetup event is triggered for each instance of the XFormControl control
        /// you need to take into consideration that any event handlers will affect all XForms for the entire
        /// application. If the EPiServer UI is running in the same application this might also be affected depending
        /// on which events you attach to and what is done in the event handlers.</remarks>
        public void XForm_ControlSetup(object sender, EventArgs e)
        {
            XFormControl control = (XFormControl)sender;

            control.BeforeLoadingForm += new LoadFormEventHandler(XForm_BeforeLoadingForm);
            control.AfterSubmitPostedData += new SaveFormDataEventHandler(XForm_AfterSubmitPostedData);
        }

        /// <summary>
        /// Handles the BeforeLoadingForm event of the XFormControl.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EPiServer.XForms.WebControls.LoadFormEventArgs"/> instance containing the event data.</param>
        public void XForm_BeforeLoadingForm(object sender, LoadFormEventArgs e)
        {
            XFormControl formControl = (XFormControl)sender;
            if (String.IsNullOrEmpty(formControl.ValidationGroup))
            {
                //We set the validation group of the form to match our global validation group in the master page if no group has been defined.
                formControl.ValidationGroup = "XForm_" + Guid.NewGuid().ToString();
            }
        }

        /// <summary>
        /// Handles the AfterSubmitPostedData event of the XFormControl.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EPiServer.XForms.WebControls.SaveFormDataEventArgs"/> instance containing the event data.</param>
        public void XForm_AfterSubmitPostedData(object sender, SaveFormDataEventArgs e)
        {
            XFormControl control = (XFormControl)sender;

            if (control.FormDefinition.PageGuidAfterPost != Guid.Empty)
            {
                PermanentContentLinkMap pageMap = PermanentLinkMapStore.Find(control.FormDefinition.PageGuidAfterPost) as PermanentContentLinkMap;
                if (pageMap != null)
                {
                    string internalUrl = pageMap.MappedUrl.ToString();
                    internalUrl = UriSupport.AddLanguageSelection(internalUrl, ContentLanguage.PreferredCulture.Name);
                    UrlBuilder urlBuilder = new UrlBuilder(internalUrl);
                    //Rewrite the url to make sure that it gets the friendly url if such a provider has been configured.
                    Global.UrlRewriteProvider.ConvertToExternal(urlBuilder, null, Encoding.UTF8);

                    //Always cast UrlBuilders to get a correctly encoded url since ToString() is for "human" readability.
                    control.Page.Response.Redirect((string)urlBuilder);
                    return;
                }
            }

            //After the form has been posted we remove the form elements and add a "thank you message".
            control.Controls.Clear();
            Label label = new Label();
            label.CssClass = "thankyoumessage";
            label.Text = LocalizationService.Current.GetString("/form/postedmessage");
            control.Controls.Add(label);
        }

        #endregion

        /// <summary>
        /// Group names for content types and properties
        /// </summary>
        public static class GroupNames
        {
            public const string Contact = "Contact";
            public const string Default = "Default";
            public const string MetaData = "Metadata";
            public const string News = "News";
            public const string Products = "Products";
            public const string SiteSettings = "SiteSettings";
            public const string Specialized = "Specialized";
        }

        /// <summary>
        /// Tags to use for the main widths used in the Bootstrap HTML framework
        /// </summary>
        public static class ContentAreaTags
        {
            public const string FullWidth = "span12";
            public const string TwoThirdsWidth = "span8";
            public const string HalfWidth = "span6";
            public const string OneThirdWidth = "span4";
        }

        /// <summary>
        /// Main widths used in the Bootstrap HTML framework
        /// </summary>
        public static class ContentAreaWidths
        {
            public const int FullWidth = 12;
            public const int TwoThirdsWidth = 8;
            public const int HalfWidth = 6;
            public const int OneThirdWidth = 4;
        }

        /// <summary>
        /// Names used for UIHint attributes to map specific rendering controls to page properties
        /// </summary>
        public static class SiteUIHints
        {
            public const string Contact = "contact";
            public const string Strings = "StringList";
        }

        /// <summary>
        /// Virtual path to folder with static graphics, such as "~/Static/gfx/"
        /// </summary>
        public const string StaticGraphicsFolderPath = "~/Static/gfx/";
    }
}