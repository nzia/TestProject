using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Templates.Alloy.Models.Blocks;

namespace EPiServer.Templates.Alloy.Views.Blocks
{
    [TemplateDescriptor(Default = true, Inherited = true, TemplateTypeCategory = TemplateTypeCategories.UserControl)]
    public partial class TeaserBlockControl : SiteBlockControlBase<TeaserBlock>
    {
        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);

            DataBind(); // Since we use data binding expressions for the Property controls' Visible property
        }

        public override int MinimumWidth
        {
            get
            {
                // If wide layout is used, the block control should be at least 2/3 wide
                return CurrentBlock.UseWideLayout ? Global.ContentAreaWidths.TwoThirdsWidth : base.MinimumWidth;
            }
            set
            {
                base.MinimumWidth = value;
            }
        }
    }
}