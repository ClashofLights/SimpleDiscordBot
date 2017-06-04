namespace SimpleDiscordBot.Modules
{
    using Discord;
    using Discord.Commands;
    using Discord.WebSocket;
    using System.Threading.Tasks;

    [Name("Core")]
    internal class Core_Module : ModuleBase<SocketCommandContext>
    {
        internal CommandService _CService = null;

        public Core_Module(CommandService CService)
        {
            this._CService = CService;
        }

        /// <summary>
        /// Example for a Command.
        /// </summary>
        /// <param name="_Host"></param>
        /// <returns></returns>
        [Command("ping", RunMode = RunMode.Async)]
        public async Task ping(string _Host = null)
        {
            EmbedBuilder _Builder = new EmbedBuilder()
            {
                Color = new Color(232, 6, 6),
                Description = $"**Pong in  {(Context.Client as DiscordSocketClient).Latency}ms** :ping_pong:",
                Footer = new EmbedFooterBuilder() { Text = $"Requested by {Context.User.Username}", IconUrl = Context.User.GetAvatarUrl() }
            };

            await ReplyAsync("", false, _Builder);
        }
    }
}
