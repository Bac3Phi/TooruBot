using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using GoogleDriveAPI;

namespace TooruBot
{
    public class Program
    {
        public static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        //public List<string> listLink = new List<string>();
        //private string pathTxt = @"E:\UIT\GIT\TestingBot\DiscordBot\DiscordBot\bin\Debug\log\0B8CoNVVZLkrqaVcwelNpR1BaZm8.txt";

        public List<string> listBoobs = new List<string>();
        private string pathBoobs = System.IO.Directory.GetCurrentDirectory()+@"\log\Boobs.txt";

        public List<string> listLoli = new List<string>();
        private string pathLoli = System.IO.Directory.GetCurrentDirectory() + @"\log\loli.txt";

        public List<string> listReal = new List<string>();
        private string pathReal = System.IO.Directory.GetCurrentDirectory() + @"\log\Real.txt";

        public List<string> listKona = new List<string>();
        private string pathKona = System.IO.Directory.GetCurrentDirectory() + @"\log\Kona.txt";

        private DiscordSocketClient _client;

        private CommandHandler _handler;
        public async Task StartAsync()
        {
            //Read txt
            exportLink(listBoobs, pathBoobs);
            exportLink(listLoli, pathLoli);
            exportLink(listReal, pathReal);
            exportLink(listKona, pathKona);
            _client = new DiscordSocketClient();

            await _client.LoginAsync(TokenType.Bot, "");
            
            await _client.StartAsync();

            _handler = new CommandHandler(_client, listBoobs, listLoli, listReal, listKona);

            _client.Log += Log;
            await Task.Delay(-1);

        }
        //`ADD 0B8CoNVVZLkrqaVcwelNpR1BaZm8 Boobs
        private Task Log(LogMessage msg)
        {
            Console.ForegroundColor = System.ConsoleColor.Yellow;
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private void exportLink(List<string> listLink, string pathTxt)// read(log.path.id) ->list random-> output
        {
            Modules.TxtProcess tx = new Modules.TxtProcess();
            listLink = tx.readTxt(listLink, pathTxt);
        }


        // cmdADD(folderID,cmdID)-> ExportLink()-> get.folderID ->list->printtxt(pathID.cmdID)->output
      
    }
}
