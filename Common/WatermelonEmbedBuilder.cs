using Discord;
using Discord.WebSocket;

namespace Watermelon.Common
{
    internal class WatermelonEmbedBuilder : EmbedBuilder
    {
        public WatermelonEmbedBuilder(SocketGuildUser user)
        {
            Color = new Color(238, 62, 75);
            ThumbnailUrl = user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl();
        }
    }
}
