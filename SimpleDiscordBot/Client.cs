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
                _Token = Token;

                _Client = new DiscordSocketClient(new DiscordSocketConfig()
                {
                    LogLevel = LogSeverity.Info,
                });

                _Client.Log += this.LogHandler;

                _CommandHandler = new CommandHandler();
                _CommandHandler.InstallAsync(_Client).Wait();

                _Client.LoginAsync(TokenType.Bot, _Token);
                _Client.StartAsync();
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
