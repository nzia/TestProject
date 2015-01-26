
namespace EPiServer.Templates.Alloy.Models.Blocks
{
    /// <summary>
    /// Base class for all block types on the site
    /// </summary>
    public abstract class SiteBlockData : EPiServer.Core.BlockData
    {
        /* BEST PRACTICE TIP
         * Always use your own base class for block types in your projects,
         * instead of having your block types inherit BlockData directly.
         * That way you can easily extend all block types by modifying your base class. */
    }
}