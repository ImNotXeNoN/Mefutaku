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
using System.Net.NetworkInformation;

namespace Mefutaku_For_Discord.Commands.Networking
{
    class Pinger
    {
        public class Pingu : ModuleBase<SocketCommandContext>
        {
            [Command("ping")]
            public async Task PingAsync([Remainder] string IP = "Empty")
            {
                if (IP == "Empty")
                {
                    await ReplyAsync("Invalid Usage - a!ping 1.3.3.7");
                    Console.WriteLine("[Command] | The Command a!ping was ran, However there was no input");
                }
                else
                {
                    Ping ping = new Ping();
                    PingReply reply = ping.Send(IP, 500);

                    if (reply.Status.ToString().Equals("Success"))
                    {
                        await ReplyAsync("Pinged [" + IP + "] Returned 5 Packets");
                        Console.WriteLine("[Command] | The Command a!ping Was Ran On The IP : " + IP + " Returned 5 Packets");
                    }
                    else
                    {
                        await ReplyAsync("`Pinged[" + IP + "] Returned 5 Packets`");
                        Console.WriteLine("[Command] | The Command a!ping Was Ran On The IP : " + IP + " Returned 0 Packets");

                    }
                }
            }
        }
    }
}
