namespace SimpleDiscordBot
{
    using Discord.Commands;
    using Discord.WebSocket;
    using System.Threading.Tasks;
    using Modules;

    internal class CommandHandler
    {
        internal DiscordSocketClient _DiscordClient = null;
        internal CommandService _CommandService = null;

        public async Task InstallAsync(DiscordSocketClient DiscordClient)
        {
            this._DiscordClient = DiscordClient;
            this._CommandService = new CommandService();

            await this._CommandService.AddModuleAsync(typeof(Core_Module));

            this._DiscordClient.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage _SocketMessage)
        {
            SocketUserMessage _Message = _SocketMessage as SocketUserMessage;
            if (_Message == null)
            {
                return;
            }

            SocketCommandContext _Context = new SocketCommandContext(_DiscordClient, _Message);

            int argPos = 0;
            if (_Message.HasStringPrefix(Program._Prefix, ref argPos) || _Message.HasMentionPrefix(_DiscordClient.CurrentUser, ref argPos))
            {
                Log.Execute($"Command {_Message.Content} has been executed by {_Message.Author.Username} in {_Message.Channel}");

                IResult result = await _CommandService.ExecuteAsync(_Context, argPos);
            }
        }
    }
}
