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

namespace Mefutaku_For_Discord.Commands
{
    class Helper
    {
        public class HELP : ModuleBase<SocketCommandContext>
        {
            [Command("help")]
            public async Task help([Remainder] string Input = "Empty")
            {
                EmbedBuilder Bot = new EmbedBuilder();
                Bot.WithAuthor("Mefutaku - Help");
                Bot.WithColor(98, 14, 194);
                Bot.WithFooter("Command Ran - a!help - Github.com/ImNotXeNoN");
                Bot.WithDescription("****a!Networking****\n`Displays All The Networking Commands.`\n****a!Moderation****\n`Displays All The Networking Commands.`\n****a!Fun****\n`Displays All The Fun Commands.`");
                Bot.WithThumbnailUrl("https://i.imgur.com/hD5OvmJ.png");

                Console.WriteLine("[Command] | The Command a!help was ran!");

                await Context.Channel.SendMessageAsync("", false, Bot.Build());
            }
        }
    }
}
