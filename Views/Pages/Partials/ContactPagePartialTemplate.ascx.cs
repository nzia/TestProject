using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Templates.Alloy.Models.Pages;

namespace EPiServer.Templates.Alloy.Views.Pages.Partials
{
    [TemplateDescriptor(Inherited = true, TemplateTypeCategory = TemplateTypeCategories.UserControl)]
    public partial class ContactPagePartialTemplate : PartialPageTemplate<ContactPage>
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            DataBind(); // We use data-binding expressions to make the relevant layout visible
        }

        public override string ContainerCssClass
        {
            get
            {
                return base.ContainerCssClass + " teaserblock"; // Contact pages are styled like teasers
            }
            set
            {
                base.ContainerCssClass = value;
            }
        }
    }
}