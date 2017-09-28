using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;
using System.Reflection;

namespace TooruBot
{
    public class CommandHandler
    {
        private DiscordSocketClient _client;

        private CommandService _service;


        public CommandHandler(DiscordSocketClient client, List<string> listBoobs, List<string> listLoli, List<string> listReal, List<string> listKona)
        {
            
            _client = client;

            _service = new CommandService();

            _service.AddModulesAsync(Assembly.GetEntryAssembly());

            _client.MessageReceived += HandleCommandAsync;

            Modules.cmd._listBoobs = listBoobs;
            Modules.cmd._listLoli = listLoli;
            Modules.cmd._listReal = listReal;
            Modules.cmd._listKona = listKona;
            _service.AddModuleAsync(typeof(Modules.cmd));
            _client.SetGameAsync("Mãng Cầu-Chan", null, Discord.StreamType.NotStreaming);


        }

        private async Task HandleCommandAsync(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;

            var context = new SocketCommandContext(_client, msg);

            int argPos = 0;
            if (msg.HasCharPrefix('`', ref argPos))
            {
                var result = await _service.ExecuteAsync(context, argPos);

                if (!result.IsSuccess && result.Error != CommandError.UnknownCommand)
                {
                    await context.Channel.SendMessageAsync(result.ErrorReason);
                }
            }

        }
    }
}
