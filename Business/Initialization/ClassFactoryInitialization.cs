using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.SpecializedProperties;
using EPiServer.Templates.Alloy.Business.WebControls;
using EPiServer.Framework.Initialization;

namespace EPiServer.Templates.Alloy.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(Web.InitializationModule))]
    public class ClassFactoryInitialization : IInitializableModule
    {
        public void Initialize(Framework.Initialization.InitializationEngine context)
        {
            if (context.HostType == HostType.WebApplication)
            {
                // Use our own control to render content areas
                PropertyControlClassFactory.Instance.RegisterClass(
                    typeof(PropertyContentArea), // We want to use our own control whenever a PropertyContentArea property is rendered
                    typeof(SitePropertyContentAreaControl)); // Use our own control derived from PropertyContentAreaControl, customized for the Bootstrap HTML framework
            }
        }

        public void Preload(string[] parameters) { }

        public void Uninitialize(Framework.Initialization.InitializationEngine context) { }
    }
}