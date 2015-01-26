using System;
using EPiServer.Templates.Alloy.Models.Blocks;
using EPiServer.Web;

namespace EPiServer.Templates.Alloy.Views.Blocks
{
    public partial class VideoBlockControl : SiteBlockControlBase<VideoBlock>
    {
        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);

            ScriptUrl = Page.ResolveUrl("~/Static/jwplayer/jwplayer.js");
            PlayerUrl = Page.ResolveUrl("~/Static/jwplayer/player.swf");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            VideoUrl = CurrentBlock.VideoBlockUrl != null ? CurrentBlock.VideoBlockUrl.ToString() : string.Empty;
            
            PreviewImageUrl = CurrentBlock.VideoPreviewImageUrl != null ? CurrentBlock.VideoPreviewImageUrl.ToString() : string.Empty;

            embed.ApplyEditAttributes<VideoBlock>(b => b.VideoBlockUrl);

            // Trigger full page reload when block is updated in edit mode (requires FullRefreshPropertiesMetaData control in Root.Master)
            var page = Page as PageBase;

            if (page != null)
            {
                if (!page.EditHints.Contains("VideoBlockUrl"))
                {                  
                    page.EditHints.Add("VideoBlockUrl");
                    page.EditHints.Add("VideoPreviewImageUrl");
                }
            }
            
            DataBind();
        }

        /// <summary>
        /// Gets the virtual path to the local video player
        /// </summary>
        public string PlayerUrl { get; set; }

        /// <summary>
        /// Gets the virtual path to the local video player script
        /// </summary>
        public string ScriptUrl { get; set; }

        /// <summary>
        /// Gets or sets the absolute URL of the video to play/embed
        /// </summary>
        public string VideoUrl { get; set; }

        /// <summary>
        /// Gets or sets the absolute path of the preview image to display before the video is played
        /// </summary>
        public string PreviewImageUrl { get; set; }
    }
}
