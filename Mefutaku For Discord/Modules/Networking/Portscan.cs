using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Discord;
using Discord.Addons;
using Discord.Commands;
using Discord.Net;
using Discord.Net.WebSockets;
using Discord.Net.Converters;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace Mefutaku_For_Discord.Commands.Tools
{
    class Portscan
    {
        public class Ports : ModuleBase<SocketCommandContext>
        {
            [Command("scan")]
            public async Task Bot([Remainder] string HOST = "Empty")
            {
                if (HOST == "Empty")
                {
                    await ReplyAsync("Hey There Invalid Usage, Please Use a!scan IP.");
                    Console.WriteLine("[Command] | The Command a!scan was ran, However there was no input");
                }
                else
                {
                    Console.WriteLine("[Command] | The Command a!scan was ran On The IP : " + HOST + " Successfully Scanned Common TCP Ports");
                    var webRequest = WebRequest.Create(@"https://api.hackertarget.com/nmap/?q=" + HOST);
                    using (var response = webRequest.GetResponse())
                    using (var content = response.GetResponseStream())
                    using (var reader = new StreamReader(content))
                    {
                        var responsefromsrv = reader.ReadToEnd();
                        EmbedBuilder Bot = new EmbedBuilder();
                        Bot.WithColor(98, 14, 194); // RGB
                        Bot.WithFooter("Command Ran - a!hscan - Github.com/ImNotXeNoN");
                        Bot.WithDescription(responsefromsrv);
                        await Context.Channel.SendMessageAsync("", false, Bot.Build());
                    }
                }
            }
        }
    }
}
