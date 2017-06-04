namespace SimpleDiscordBot
{
    using Discord;
    using Discord.WebSocket;
    using System;
    using System.Threading.Tasks;

    internal class Client
    {
        internal DiscordSocketClient _Client    = null;
        internal CommandHandler _CommandHandler = null;
        internal string _Token                  = string.Empty;
        internal long _ID                       = 0;

        internal Client(string Token)
        {
            try
            {
                this._Token = Token;

                this._Client = new DiscordSocketClient(new DiscordSocketConfig()
                {
                    LogLevel = LogSeverity.Info,
                });

                this._Client.Log += this.LogHandler;

                this._CommandHandler = new CommandHandler();
                this._CommandHandler.InstallAsync(this._Client).Wait();

                this._Client.LoginAsync(TokenType.Bot, this._Token);
                this._Client.StartAsync();
            }
            catch (Exception _Exception)
            {
                Log.Error($"Error: {_Exception.Message} at {_Exception.Source}");
            }
        }

        internal async Task LogHandler(LogMessage _Log)
        {
            try
            {
                Log.Debug($"Info {_Log.Message} at {DateTime.UtcNow}");
            }
            catch (Exception _Exception)
            {
                Log.Error($"Error: {_Exception.Message}");
            }
        }
    }
}
