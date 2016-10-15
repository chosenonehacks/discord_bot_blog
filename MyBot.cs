using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBot3
{
    public class MyBot
    {
            private static DiscordClient discord;
            CommandService commands;
            
            public MyBot()
            {
                discord = new DiscordClient(x =>
                {
                    x.LogLevel = LogSeverity.Debug;
                    x.LogHandler = Log;
                });

                discord.UsingCommands(x =>
                {
                    x.PrefixChar = '!';
                    x.AllowMentionPrefix = true;
                    x.HelpMode = HelpMode.Public;
                });

                commands = discord.GetService<CommandService>();

                RegisterCommands();

                discord.ExecuteAndWait(async () =>
                {
                    await discord.Connect("MjM2ODA0ODAxMjA2MTU3MzEy.CuPldA.A3Z54yeaCzAf2KbRayM1mp63IUE", TokenType.Bot);
                });
            }

            private void Log(object sender, LogMessageEventArgs e)
            {
                Console.WriteLine(e.Message);
            }

            #region Text Commands
            private void RegisterCommands()
            {

                commands.CreateCommand("say")                                // The command text `!say <text>`
                .Description("Make the bot say something")          // The command's description
                .Alias("s")                                         // An alternate trigger for this command `!s <text>`                                                                    
                .Parameter("text", ParameterType.Unparsed)          // The parameter for this command
                .Do(async (e) =>                                    // The code to be run when the command is executed
                    {
                        string text = e.Args[0]; //take first argument
                        await e.Channel.SendMessage(text); //send text to channel
                    });

                commands.CreateCommand("botPic")
                .Alias("pic")
                .Do(async (e) =>
                {
                    await e.Channel.SendFile("Media/bot.png"); //this command sends picture to channel
                });
            }
            #endregion
        }
    }

