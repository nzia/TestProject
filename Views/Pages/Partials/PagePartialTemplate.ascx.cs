using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Templates.Alloy.Models.Pages;
using EPiServer.Web;

namespace EPiServer.Templates.Alloy.Views.Pages.Partials
{
    /// <summary>
    /// Renders a product page teaser when a product page is dropped in a content area
    /// </summary>
    [TemplateDescriptor(Inherited = true, TemplateTypeCategory = TemplateTypeCategories.UserControl)]
    public partial class PagePartialTemplate : PartialPageTemplate<SitePageData>
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            // Ensure teaser texts are editable in on-page edit mode
            if (CurrentData.ContentLink.CompareToIgnoreWorkID(CurrentPage.ContentLink))
            {
                TeaserTextStandard.ApplyEditAttributes<SitePageData>(p => p.TeaserText);
                TeaserTextWide.ApplyEditAttributes<SitePageData>(p => p.TeaserText);
            }

            DataBind();
        }

        public override string ContainerCssClass
        {
            get
            {
                return string.Join(" ", base.ContainerCssClass, "teaserblock").Trim(); // A product is rendered like a teaser block
            }
            set
            {
                base.ContainerCssClass = value;
            }
        }
    }
}