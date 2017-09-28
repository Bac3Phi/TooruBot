using Discord;
using Discord.Commands;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TooruBot.Modules
{
    [DontAutoLoad]
    public class cmd : ModuleBase
    {
        //public static List<string> _listLink = new List<string>();
        public static List<string> _listBoobs = new List<string>();
        public static List<string> _listLoli = new List<string>();
        public static List<string> _listReal = new List<string>();
        public static List<string> _listKona = new List<string>();
        //public cmd(List<string> listLink)
        //{
        //    _listLink = listLink;
        //}
        Random random = new Random();
        EmbedBuilder eb;


        #region NSFW

        [Command("Kona")]
        public async Task Kona()
        {

            if (Context.Channel.IsNsfw)
            {
                var footer = new EmbedFooterBuilder();
                footer.IconUrl = Context.User.GetAvatarUrl();
                footer.Text = "Request by " + Context.User.Username;

                int randList = random.Next(_listKona.Count);
                eb = new EmbedBuilder();
                eb.WithColor(Color.LightOrange);
                eb.WithImageUrl(_listKona[randList].ToString());
                eb.WithFooter(footer);
                await Context.Channel.SendMessageAsync("", false, eb);
            }
            else await Context.Channel.SendMessageAsync("Bạn không được phép sử dụng lệnh này tại #" + Context.Channel.Name);

        }
        [Command("Boobs")]
        public async Task Boobs()
        {

            if (Context.Channel.IsNsfw)
            {
                var footer = new EmbedFooterBuilder();
                footer.IconUrl = Context.User.GetAvatarUrl();
                footer.Text = "Request by " + Context.User.Username;

                int randList = random.Next(_listBoobs.Count);
                eb = new EmbedBuilder();
                eb.WithColor(Color.LightOrange);
                eb.WithImageUrl(_listBoobs[randList].ToString());
                eb.WithFooter(footer);
                await Context.Channel.SendMessageAsync("", false, eb);
            }
            else await Context.Channel.SendMessageAsync("Bạn không được phép sử dụng lệnh này tại #" + Context.Channel.Name);

        }
        [Command("Loli")]
        public async Task Loli()
        {

            if (Context.Channel.IsNsfw)
            {
                var footer = new EmbedFooterBuilder();
                footer.IconUrl = Context.User.GetAvatarUrl();
                footer.Text = "Request by " + Context.User.Username;

                int randList = random.Next(_listLoli.Count);
                eb = new EmbedBuilder();
                eb.WithColor(Color.LightOrange);
                eb.WithImageUrl(_listLoli[randList].ToString());
                eb.WithFooter(footer);
                await Context.Channel.SendMessageAsync("", false, eb);
            }
            else await Context.Channel.SendMessageAsync("Bạn không được phép sử dụng lệnh này tại #" + Context.Channel.Name);

        }
        [Command("Real")]
        public async Task Real()
        {

            if (Context.Channel.IsNsfw)
            {
                var footer = new EmbedFooterBuilder();
                footer.IconUrl = Context.User.GetAvatarUrl();
                footer.Text = "Request by " + Context.User.Username;

                int randList = random.Next(_listReal.Count);
                eb = new EmbedBuilder();
                eb.WithColor(Color.LightOrange);
                eb.WithImageUrl(_listReal[randList].ToString());
                eb.WithFooter(footer);
                await Context.Channel.SendMessageAsync("", false, eb);
            }
            else await Context.Channel.SendMessageAsync("Bạn không được phép sử dụng lệnh này tại #" + Context.Channel.Name);

        }
        #endregion

        #region MyRegion
        [Command("Hello")]
        public async Task Hello()
        {
            await ReplyAsync("Hi! Chào mừng " + Context.Message.Author.Mention + " đến với clan House Targaryen. \nSử dụng ```Help`` để thêm thông tin lệnh!");
        }
        #endregion

        #region Help-Info

        [Command("Help")]

        public async Task Help()
        {
            var footer = new EmbedFooterBuilder();
            footer.IconUrl = "https://i.imgur.com/jfTImaZ.jpg";
            footer.Text = "House Targaryen© ver1.0.1 by BacbaPhi";


            eb = new EmbedBuilder();
            eb.WithColor(Color.DarkRed);
            eb.WithDescription("『General』 ```\n`Hello \n`Info \n`Say -[something] \n`Slap -[username] \n`Cat - triệu hồi ngay 1 bé mèo kute``` \n『NSFW』『18 +』 \n``Vui lòng liên hệ Administrator hoặc Mod để vào channel`` \n『Music』  \n``Coming Soon`` ");
            eb.WithFooter(footer);
            await Context.Channel.SendMessageAsync("", false, eb);
        }
        [Command("Info")]

        public async Task Info()
        {
            //var footer = new EmbedFooterBuilder();
            //footer.IconUrl = "https://i.imgur.com/jfTImaZ.jpg";
            //footer.Text = "House Targaryen© ver1.0.1 by BacbaPhi";


            eb = new EmbedBuilder();
            eb.WithColor(Color.Blue);
            eb.WithDescription("House Targaryen© ver1.0.1 by BacbaPhi \nContact me via fb: `fb.com/PhiGKZ`");

            await Context.Channel.SendMessageAsync("", false, eb);
        }
        #endregion

        #region SampleCMD
        [Command("Slap")]
        public async Task Slap([Remainder]string username)
        {
            string[] img = { "https://i.imgur.com/sj6CupK.gif", "https://i.imgur.com/EMxSdg2.gif","https://i.imgur.com/FJxRfEN.gif"," https://i.imgur.com/wdB7zmz.gif","https://i.imgur.com/MJpAlGv.gif" };
            int randList = random.Next(img.Length);
            await ReplyAsync(username + ", Chị Im đi!!!"); //+ Context.Message.Author.Mention);
            var footer = new EmbedFooterBuilder();
            footer.IconUrl = Context.User.GetAvatarUrl();
            footer.Text = "Request by " + Context.User.Username;
            eb = new EmbedBuilder();
           // eb.WithTitle(username + " Slap " + Context.Message.Author.Mention);
            eb.WithColor(Color.DarkMagenta);
            eb.WithImageUrl(img[randList]);
            eb.WithFooter(footer);
            await Context.Channel.SendMessageAsync("", false, eb);

        }
        [Command("Lick")]
        public async Task lick([Remainder]string username)
        {
            string[] img = {"https://i.imgur.com/HbbpT56.gif","https://i.imgur.com/JO6jcbI.gif","https://i.imgur.com/DLyHsCb.gif","https://i.imgur.com/knYZaU4.gif","https://i.imgur.com/bxlslsy.gif" };
            int randList = random.Next(img.Length);

            await ReplyAsync(username + ", Cho lick miếng ykkkk!!"); //+ Context.Message.Author.Mention);
            var footer = new EmbedFooterBuilder();
            footer.IconUrl = Context.User.GetAvatarUrl();
            footer.Text = "Request by " + Context.User.Username;
            eb = new EmbedBuilder();
            // eb.WithTitle(username + " Slap " + Context.Message.Author.Mention);
            eb.WithColor(Color.DarkPurple);
            eb.WithImageUrl(img[randList]);
            eb.WithFooter(footer);
            await Context.Channel.SendMessageAsync("", false, eb);

        }
        [Command("Say")]
        public async Task Say([Remainder] string say)
        {
        
            await ReplyAsync(say);
        }

        [Command("Cat")]
        [Summary("Meo")]
        public async Task Cat() //You can add what ever you want your function to be named here
        {
            var footer = new EmbedFooterBuilder();
            footer.IconUrl = Context.User.GetAvatarUrl();
            footer.Text = "Request by " + Context.User.Username;
            //Console.WriteLine("Chờ Tooru 1 tý...");


            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate })) //This acts like a webbrowser
            {
                string websiteurl = "http://random.cat/meow";                           //The API site
                client.BaseAddress = new Uri(websiteurl);                                   //This redirects the code to the API?
                HttpResponseMessage response = client.GetAsync("").Result;   //Then it gets the information
                response.EnsureSuccessStatusCode();                                       //Makes sure that its successfull
                string result = await response.Content.ReadAsStringAsync();     //Gets the full website
                var json = JObject.Parse(result);                                                //Reads the json from the html (?)

                string CatImage = json["file"].ToString();
                //Saves the url to CatImage string
                eb = new EmbedBuilder();
                eb.WithColor(Color.Blue);
                eb.WithTitle("Chờ 1 tý... <3 ");
                eb.WithImageUrl(CatImage);
                eb.WithFooter(footer);
                await Context.Channel.SendMessageAsync("", false, eb);
                //Sends the the picture <3
            }


        }
        #endregion





        #region AddFolder

        [Command("Add")]
        [Summary("add saurce")]
        public async Task Plus( string folderID, string cmdID) //problem here
        {

            if (Context.Channel.IsNsfw)
            {
                switch (cmdID)
                {
                    case "Boobs":
                        GetLinkDrive(_listBoobs, folderID, cmdID); break;
                    case "Loli":
                        GetLinkDrive(_listLoli, folderID, cmdID); break;
                    case "Real":
                        GetLinkDrive(_listReal, folderID, cmdID); break;
                    case "Kona":
                        GetLinkDrive(_listKona, folderID, cmdID); break;
                    default:
                        await Context.Channel.SendMessageAsync("``Sai cú pháp!``");
                        break;
                }

                // GetLinkDrive(listLink, folderID, cmdID);
                await Context.Channel.SendMessageAsync("Add successful! Folder`" + folderID + "` => `" + cmdID );
            }
            else
            {
                await Context.Channel.SendMessageAsync("``Bạn không đủ quyền để thực hiện lệnh này!``");
            }


        }

        private void GetLinkDrive(List<string> listLink, string folderID, string cmdID)
        {
            string pathTxt = System.IO.Directory.GetCurrentDirectory() + "\\log\\" + cmdID + ".txt";            // System.IO.Directory.GetCurrentDirectory() + ;
            List<string> listLinkNew = new List<string>();
            GoogleDriveAPI.ExportLink ex = new GoogleDriveAPI.ExportLink();
            Modules.TxtProcess txt = new Modules.TxtProcess();

            listLinkNew = ex.connector(listLinkNew, folderID);
            txt.printTxt(listLinkNew, pathTxt);
            listLink = txt.readTxt(listLink, pathTxt);
        }

        #endregion

        [Command("Clear")]
        public async Task clear([Remainder] int Delete = 0)
        {
            IGuildUser Bot = await Context.Guild.GetUserAsync(Context.Client.CurrentUser.Id);
            if (!Bot.GetPermissions(Context.Channel as ITextChannel).ManageMessages)
            {
                await Context.Channel.SendMessageAsync("`Bot does not have enough permissions to manage messages`");
                return;
            }
            await Context.Message.DeleteAsync();
            var GuildUser = await Context.Guild.GetUserAsync(Context.User.Id);
            if (!GuildUser.GetPermissions(Context.Channel as ITextChannel).ManageMessages)
            {
                await Context.Channel.SendMessageAsync("`You do not have enough permissions to manage messages`");
                return;
            }
            if (Delete == null)
            {
                await Context.Channel.SendMessageAsync("`You need to specify the amount | !clear (amount) | Replace (amount) with anything`");
            }
            int Amount = 0;
            foreach (var Item in await Context.Channel.GetMessagesAsync(Delete).Flatten())
            {

                Amount++;
                await Item.DeleteAsync();

            }
            await Context.Channel.SendMessageAsync($"`{Context.User.Username} deleted {Amount} messages`");
        }


    }
}
