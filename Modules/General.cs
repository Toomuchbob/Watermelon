using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Net.Http;
using System.Threading.Tasks;
using Watermelon.Common;
using Watermelon.Models;

namespace Watermelon.Modules
{
    public class General : ModuleBase<SocketCommandContext>
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public General(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Command("ping")] // the full named command
        [Alias("p")] // shortend command (optional)
        [RequireUserPermission(GuildPermission.Administrator)] // check that a user has the required permission
        public async Task PingAsync()
        {
            await ReplyAsync("Pong!");
        }

        [Command("info")]
        public async Task InfoAsync(SocketGuildUser socketGuildUser = null)
        {
            if (socketGuildUser == null)
            {
                socketGuildUser = Context.User as SocketGuildUser;
            }

            var embed = new WatermelonEmbedBuilder(socketGuildUser)
                .WithTitle($"{socketGuildUser.Username}#{socketGuildUser.Discriminator}")
                .AddField("ID", socketGuildUser.Id, true)
                .AddField("Name", $"{ socketGuildUser.Username}#{socketGuildUser.Discriminator}", true)
                .AddField("Created At", socketGuildUser.CreatedAt, true)
                .WithCurrentTimestamp()
                .Build();

            await ReplyAsync(embed: embed);
        }

        [Command("activity")]
        public async Task Venture()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetStringAsync("https://www.boredapi.com/api/activity");
            var venture = Models.Venture.FromJson(response);

            if (venture is null)
            {
                await ReplyAsync("An error occured, please try again later.");
                return;
            }

            await ReplyAsync($"**Venture:** { venture.Activity }\n**Participants:** { venture.Participants }\n**Type:** { venture.Type }");
        }
    }
}
