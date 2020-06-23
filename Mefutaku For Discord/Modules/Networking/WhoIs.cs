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

namespace Mefutaku_For_Discord.Commands.Networking
{
    class WhoIs
    {
        public class wisearch : ModuleBase<SocketCommandContext>
        {
            [Command("wisearch")]
            public async Task Bot([Remainder] string HOST = ",Empty")
            {
                if (HOST == "Empty")
                {
                    await ReplyAsync("Hey There Invalid Usage, Please Use a!wisearch HOST.");
                    Console.WriteLine("[Command] | The Command a!whois was ran, However there was no input");
                }
                else
                {
                    Console.WriteLine("[Command] | The Command a!wisearch was ran On The Host : " + HOST + " Successfully Conducted A WhoIs Search");
                    var webRequest = WebRequest.Create(@"https://api.hackertarget.com/whois/?q=" + HOST);
                    using (var response = webRequest.GetResponse())
                    using (var content = response.GetResponseStream())
                    using (var reader = new StreamReader(content))
                    {
                        var responsefromsrv = reader.ReadToEnd();
                        EmbedBuilder Bot = new EmbedBuilder();
                        Bot.WithColor(98, 14, 194); // RGB
                        Bot.WithFooter("Command Ran - a!wisearch - Github.com/ImNotXeNoN");
                        Bot.WithDescription(responsefromsrv);
                        await Context.Channel.SendMessageAsync("", false, Bot.Build());
                    }
                }
            }
        }
    }
}
