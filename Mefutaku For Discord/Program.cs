/* 
The Prefix Is Set As a! you can change this on line 103
And the token on 48
The Prefix Is Set As a! Due to me testing the bot in a server with a bot which has the prefix m!
Developed By XeNoN - Github/ImNotXeNoN
*/

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

namespace Mefutaku_For_Discord
{
    class Program
    {
        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;
        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();
            string botToken = "Token";

            _client.Log += Log;

            await _client.LoginAsync(Discord.TokenType.Bot, botToken);

            await RegisterCommandsAsync();

            await _client.LoginAsync(Discord.TokenType.Bot, botToken);

            await _client.SetGameAsync("a!help - Mefutaku", null, ActivityType.Playing);

            await _client.StartAsync();

            await Task.Delay(-1);
        }


        private Task Log(LogMessage arg)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(arg);
            Thread.Sleep(333);
            Console.Title = "Listener Started - Mefutaku";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("[Listener] | Has Started | [Mefutaku Discord Bot]");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[Alert] | Future Updates Can Be Found Here [Github.com/ImNotXeNoN/Mefutaku]");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[Alert] | Mefutaku's Main Purpose Is To Help People To Understand/Learn C# And Get Into Coding!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[Token] | If The Bot Is Not Functoning Check Your Token!");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Red;
            return Task.CompletedTask;

        }

        public async Task RegisterCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        public async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;

            if (message is null || message.Author.IsBot) return;

            int argPos = 0;

            if (message.HasStringPrefix("a!", ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(_client, message);

                var result = await _commands.ExecuteAsync(context, argPos, _services);

                if (!result.IsSuccess)
                {
                    Console.WriteLine(result.ErrorReason);
                }
            }
        }
    }
}         