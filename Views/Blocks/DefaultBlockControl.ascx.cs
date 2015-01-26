using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Templates.Alloy.Models.Blocks;

namespace EPiServer.Templates.Alloy.Views.Blocks
{
    [TemplateDescriptor(
        AvailableWithoutTag = true, 
        Inherited = true, 
        TemplateTypeCategory = TemplateTypeCategories.UserControl)]
    public partial class DefaultBlockControl : SiteBlockControlBase<SiteBlockData>
    {

    }
}