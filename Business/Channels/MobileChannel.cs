using System.Web;
using EPiServer.Web;

namespace EPiServer.Templates.Alloy.Business.Channels
{
    /// <summary>
    /// Defines the 'Mobile' content channel
    /// </summary>
    public class MobileChannel : DisplayChannel
    {
        public override string ChannelName
        {
            get
            {
                return LocalizationService.GetString("/channels/mobile");
            }
        }

        public override string ResolutionId
        {
            get
            {
                return typeof(IphoneVerticalResolution).FullName;
            }
        }

        public override bool IsActive(HttpContextBase context)
        {
            return context.Request.Browser.IsMobileDevice;
        }
    }
}