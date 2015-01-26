using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Templates.Alloy.Business;
using EPiServer.Templates.Alloy.Models.Blocks;
using EPiServer.Templates.Alloy.Models.Pages;
using EPiServer.Web;
using log4net;

namespace EPiServer.Templates.Alloy.Views.Blocks
{
    [TemplateDescriptor(Inherited = true, TemplateTypeCategory = TemplateTypeCategories.UserControl)]
    public partial class FormBlockControl : SiteBlockControlBase<FormBlock>
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(FormBlockControl));
    }
}