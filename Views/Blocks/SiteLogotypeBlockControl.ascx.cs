using EPiServer.Framework.DataAnnotations;
using EPiServer.Templates.Alloy.Models.Blocks;
using EPiServer.Web;

namespace EPiServer.Templates.Alloy.Views.Blocks
{
    [TemplateDescriptor(
        AvailableWithoutTag = false,
        Tags = new [] { "Header" })] // This block control is only allowed to be dropped in an area tagged with 'Header' through its RenderSettings property
    public partial class SiteLogotypeBlockControl : BlockControlBase<SiteLogotypeBlock>
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            logo.DataBind();

            // In on-page edit mode, clicking the logo should allow editor to change the logotype graphic
            logo.ApplyEditAttributes<SiteLogotypeBlock>(b => b.SiteLogotypeUrl);
        }  

        protected string LogotypeUrl
        {
            get
            {
                return CurrentBlock.SiteLogotypeUrl.ToString();
            }
        }
    }
}