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

namespace Mefutaku_For_Discord.Commands.Help
{
    class NetworkingHelp
    {
        public class Networking : ModuleBase<SocketCommandContext>
        {
            [Command("Networking")]
            public async Task Networkingjo([Remainder] string Input = "Empty")
            {
                EmbedBuilder Bot = new EmbedBuilder();
                Bot.WithAuthor("Mefutaku - Networking");
                Bot.WithColor(98, 14, 194);
                Bot.WithFooter("Command Ran - a!Networking - Github.com/ImNotXeNoN");
                Bot.WithDescription("****a!Scan****\n`Scans Common TCP Ports Example a!Scan 1.3.3.7`\n****a!WiSearch****\n`Conducts A WhoIs Search Example a!WiSearch 1.3.3.7 `\n****a!Ping****\n`Pings The Target Host Example a!Ping 1.3.3.7`\n****a!GeoIP****\n`Conducts A GeoIP Search On The Target Host Example a!GeoIp 1.3.3.7`");
                Bot.WithThumbnailUrl("https://cdn.theatlantic.com/thumbor/t1jzUVpre_vQ6oQgD5dJJM3yIxg=/0x218:4288x2630/720x405/media/img/mt/2014/05/shutterstock_132463994/original.jpg");

                Console.WriteLine("[Command] | The Command a!Networking was ran!");

                await Context.Channel.SendMessageAsync("", false, Bot.Build());
            }
        }
    }
}

