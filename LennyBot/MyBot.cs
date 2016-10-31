using Discord;
using Discord.Commands;

using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Google;

namespace LennyBot
{
    class MyBot
    {
        Timer t = new Timer(TimerCallback, null, 0, 2000);
        WebClient webClient = new WebClient();
        static DiscordClient discord;
        static CommandService commands;
        static Random rdm = new Random();
        #region Duel Vars
        string weapon;
        int damage;
        int lenHealth = 100;
        int userHealth = 100;
        string fighter;
        #endregion
        bool ecc = false;
        string eccMessage;
        #region Lottery Vars
        static DateTime lotteryEnd;
        static bool lotteryOn = false;
        static int lotteryPrize = 0;
        //int lotteryMultiplier = 0; //do somethin
        int lotteryEntry = 0;
        static Channel lotChannel;
        #endregion
        #region Sleep Times
        static DateTime dateNow = DateTime.Now;
        static DateTime lennySleep = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 21, 55, 0);
        static DateTime lennySleep2 = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 21, 59, 0);
        static DateTime lennySleep3 = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day, 21, 59, 50);
        #endregion
        #region Time Spans
        TimeSpan fiveMin = new TimeSpan(0, 5, 0);
        TimeSpan oneHour = new TimeSpan(1, 0, 0);
        TimeSpan oneMin = new TimeSpan(0, 1, 0);
        #endregion
        #region Bee Movie Vars
        static TimeSpan sendDelay;
        static DateTime sendTime;
        static Channel beeChannel;
        static bool bmOn = false;
        static string[] beeScript = File.ReadAllLines("TextFiles/TheBeeMovieScript.txt");
        #endregion
        #region Poll Vars
        static string[] pollOption = new string[6];
        static int[] pollOptionVotes = new int[6];
        bool[] pollUserVoted = new bool[100];
        static int itemNum;
        string poll;
        static bool pollOn = false;
        static TimeSpan pollDuration;
        static DateTime pollEnd;
        static Channel pollChannel;
        static string pollTitle;
        static int pollTotalVotes;
        #endregion
        bool[] creatingRole = new bool[100];
        static Properties.Settings set = new Properties.Settings();
        Google.API.Search.GimageSearchClient imageClient = new Google.API.Search.GimageSearchClient("http://www.google.com");



        public MyBot()
        {

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });
            discord.UsingCommands(x =>
            {
                x.PrefixChar = '.';
                x.AllowMentionPrefix = true;
                x.HelpMode = HelpMode.Public;

            });
            commands = discord.GetService<CommandService>();
            #region Commands
            helloCommand();
            sayCommand(null);
            susCommand();
            askCommand();
            rollCommand();
            bradyBunchMemeCommand();
            shookCommand();
            talkCommand();
            setGameCommand();
            duelCommand();
            registerCommand();
            profileCommand();
            consoleCommand();
            eccCommand();
            lotteryCommand();
            buyCommand();
            coinCommand();
            kkkCommand();
            roleCommand();
            beeMovieCommand();
            pollCommand();
            submitMemeCommand();
            memeCommand();
            giveCoinsCommand();
            eggBongoCommand();
            imageCommand();
            #endregion

            discord.ExecuteAndWait(async () =>
            {
                try
                {
                    await discord.Connect(@private.token, TokenType.Bot);
                }
                catch (System.Net.WebException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unable to connect to Discord! Check your connection!");

                }
            });

            
        }



        private void helloCommand()
        {
            commands.CreateCommand("hello")
                .Description("Says hello!")
                .Do(async (e) =>
                {
                    if (checkOwned(e.User, 1, e))
                    {
                        await e.Channel.SendMessage("Hi! ( ͡° ͜ʖ ͡°)");
                    }
                });
        }

        private void sayCommand(string input)
        {
            commands.CreateCommand("say")
                .Description("Makes me say something!")
                .Parameter("Text", ParameterType.Unparsed)
                .Do(async (e) =>
                {
                    if (checkOwned(e.User, 2, e))
                    {
                        if (input == null) await e.Channel.SendMessage(e.GetArg("Text"));
                        else await e.Channel.SendMessage(input);
                    }
                });
        }

        private void susCommand()
        {
            commands.CreateCommand("sus")
                .Description("*Sus*")
                .Alias(new string[] { "s" })
                .Do(async (e) =>
                {
                    if (checkOwned(e.User, 3, e))
                    {
                        await e.Channel.SendMessage("*sus :^)*");
                    }
                });
        }

        private void askCommand()
        {
            int qNum;
            commands.CreateCommand("ask")
                .Description("Ask me a yes or no question and I'll answer! ( ͡° ͜ʖ ͡°)")
                .Parameter("Question", ParameterType.Unparsed)
                .Do(async (e) =>
                {
                    if (checkOwned(e.User, 4, e))
                    {
                        qNum = rdm.Next(6);
                        if (qNum == 1)
                        {
                            await e.Channel.SendMessage("Yes ( ͡° ͜ʖ ͡°)");
                        }
                        else if (qNum == 2)
                        {
                            await e.Channel.SendMessage("No ( ͡° ͜ʖ ͡°)");
                        }
                        else if (qNum == 3)
                        {
                            await e.Channel.SendMessage("Ask again later ( ͡° ͜ʖ ͡°)");
                        }
                        else if (qNum == 4)
                        {
                            await e.Channel.SendMessage("lol");
                        }
                        else if (qNum == 5)
                        {
                            await e.Channel.SendMessage("( ͡° ʖ̯ ͡°)");
                        }
                    }
                });


        }

        private void rollCommand()
        {
            commands.CreateCommand("roll")
                .Description("Rolls a number between one and <num>")
                .Alias(new string[] { "r" })
                .Parameter("num", ParameterType.Required)
                .Do(async (e) =>
               {
                   if (checkOwned(e.User, 5, e))
                   {
                       int roll = rdm.Next(Convert.ToInt32(e.GetArg("num")));
                       await e.Channel.SendMessage(Convert.ToString(roll + 1));
                   }
               });
        }

        private void bradyBunchMemeCommand()
        {
            commands.CreateCommand("bradyBunchMeme")
                .Description("Picks a random meme and sends it. (Brady Bunch edition!)")
                .Alias(new string[] { "bbmem", "bbm" })
                .Do(async (e) =>
                {
                    if (e.Server.Id == 195670713183633408)
                    {
                        if (checkOwned(e.User, 6, e))
                        {
                            int picRoll = rdm.Next(77);
                            await e.Channel.SendFile($"bbmpics/{picRoll}.png");
                        }
                    }
                    else await e.Channel.SendMessage("This can only be used in the `Brady Bunch` server!");
                });
        }

        private void shookCommand()
        {
            commands.CreateCommand("shook")
                .Description("Get shook")
                .Do(async (e) =>
                {
                    if (checkOwned(e.User, 7, e))
                    {
                        await e.Channel.SendFile(@"gifs\Shook.gif");
                    }
                });
        }

        private void talkCommand()
        {
            commands.CreateCommand("talk")
                .Alias(new string[] { "t" })
                .Description("Use this to talk to me! [beta]")
                .Parameter("Text", ParameterType.Unparsed)
                .Do(async (e) =>
               {
                   if (checkOwned(e.User, 8, e))
                   {
                       string input = e.GetArg("Text");

                       if (input.Contains("thanks") || input.Contains("Thanks") || input.Contains("Thank you") || input.Contains("thank you"))
                       {
                           await e.Channel.SendMessage("Always a pleasure, " + e.User.Name + ".");
                       }
                       else if (input.Contains("hi") || input.Contains("hey") || input.Contains("Hi"))
                       {
                           await e.Channel.SendMessage("Hi! How are you, " + e.User.Name + "? ( ͡° ͜ʖ ͡°)");
                       }
                       else if (input.Contains("how are you") || input.Contains("How are you"))
                       {
                           await e.Channel.SendMessage("I'm good! ( ͡° ͜ʖ ͡°)");
                       }
                       else if (input.Contains("love you") || input.Contains("love me"))
                       {
                           await e.Channel.SendMessage("Unfortunately, as I am just a program, I am incapable of feelings such as love.");
                           await e.Channel.SendMessage("Sorry ( ͡° ʖ̯ ͡°)");
                       }
                       else if ((input.Contains("I") || input.Contains("i")) && (input.Contains("want to") || input.Contains("wish I")) && input.Contains("kill myself") || (input.Contains("die") || input.Contains("dead")))
                       {
                           await e.Channel.SendMessage("It will get better. I believe in you.");
                       }
                       else if (input.Contains("lol") || input.Contains("LOL") || input.Contains("Lol") || input.Contains("haha") || input.Contains("Haha"))
                       {
                           await e.Channel.SendMessage("Haha yes! Funny ( ͡° ͜ʖ ͡°)");
                       }
                       else if ((input.Contains("I") || input.Contains("i")) && input.Contains("don't know") || input.Contains("dont know"))
                       {
                           await e.Channel.SendMessage("I'll give you some time to think.");
                       }
                       else if (input.Contains("sorry") || input.Contains("Sorry"))
                       {
                           if (input.Contains("not sorry"))
                           {
                               await e.Channel.SendMessage("Hmph! ( ͡° ʖ̯ ͡°)");
                           }
                           else await e.Channel.SendMessage("It's okay, I forgive you. ( ͡° ͜ʖ ͡°)");
                       }
                       else if (input.Contains("fight me") || input.Contains("Fight me") || input.Contains("fight you"))
                       {
                           await e.Channel.SendMessage("I mean, I could try to fight, but I'm not sure I'd be able to.");
                           await e.Channel.SendMessage("But I give you permission to make the first move. ( ͡° ͜ʖ ͡°)");
                       }
                       else if (input.Contains("sleep") || input.Contains("Good night") || input.Contains("good night") || input.Contains("goodnight"))
                       {
                           await e.Channel.SendMessage("Goodnight, " + e.User.Name + ". Sleep well.");
                       }
                       else
                       {
                           await e.Channel.SendMessage("What? ( ͡° ʖ̯ ͡°)");
                       }

                   }
               });
        }

        private void setGameCommand()
        {
            commands.CreateCommand("setGame")
                .Alias(new string[] { "sg" })
                .Description("Sets the 'Playing <game>'")
                .Parameter("game", ParameterType.Unparsed)
                .Do(async (e) =>
               {
                   if (checkOwned(e.User, 9, e))
                   {
                       await e.Channel.SendMessage($"Game updated to {e.GetArg("game")} ");
                       discord.SetGame(e.GetArg("game"));
                       set.setGame = e.GetArg("game");
                   }

               });

        }

        #region Duel Functions
        private void duelCommand()
        {
            bool battling = false;
            fighter = null;


            commands.CreateCommand("duel")
                .Alias(new string[] { "d" })
                .Description("Fight me for Lenny Coins!")
                .Parameter("choice", ParameterType.Unparsed)
                .Do(async (e) =>
               {
                   if (checkOwned(e.User, 10, e))
                   {
                       if (!battling)
                       {
                           lenHealth = 100;
                           userHealth = 100;
                           fighter = e.User.Name;
                           await e.Channel.SendMessage(fighter + "! Prepare to duel!");

                           DuelWeaponChoose();

                           await e.Channel.SendMessage("`Choose actions using '.d [num]'!`" + Environment.NewLine +
                               "`Say '.d stop' to forfit!`" + Environment.NewLine +
                               $"`Your weapons: {weapon} [{damage} Damage]`" + Environment.NewLine +
                               "```( ͡° ͜ʖ ͡°)'s Health: [||||||||||]```" + Environment.NewLine + "```" +
                               fighter + "'s Health: [||||||||||]" + Environment.NewLine + $"[1] {weapon}" + Environment.NewLine + "[2] Defend```");

                           battling = true;
                       }
                       else
                       {
                           int lenDamage = rdm.Next(26);

                           if (e.GetArg("choice") == "") await e.Channel.SendMessage("`A battle has already been started with " + fighter + "!`");
                           else if (e.GetArg("choice") == "stop") battling = false;
                           else if (e.GetArg("choice") == "1")
                           {
                               DuelAttack();

                               await e.Channel.SendMessage($"`{fighter} attacks Lenny with {weapon} for {damage} damage!`");
                               await e.Channel.SendMessage($"`Lenny attacks {fighter} for {lenDamage} damage!`");
                               userHealth -= lenDamage;
                               await e.Channel.SendMessage(DuelDisplayInfo());

                           }
                           else if (e.GetArg("choice") == "2")
                           {
                               lenDamage /= 2;
                               await e.Channel.SendMessage($"`{fighter} braces themself for Lenny's attack`!");
                               userHealth -= lenDamage;
                               await e.Channel.SendMessage(DuelDisplayInfo());
                           }



                           if (userHealth <= 0)
                           {
                               await e.Channel.SendMessage($"`{fighter} is dead!" + Environment.NewLine + "Lenny wins!`");
                               battling = false;
                           }
                           else if (lenHealth <= 0)
                           {
                               await e.Channel.SendMessage("`Lenny is dead!" + Environment.NewLine + $"{fighter} wins! Congratulations! You have been awarded 10 Lenny Coins.`");
                               for (int i = 0; i > -1; i++)
                               {
                                   if (set.users[i] == fighter)
                                   {
                                       set.coins[i] += 10;
                                       break;
                                   }
                                   else if (set.users[i] == "0")
                                   {
                                       await e.Channel.SendMessage("Profile not found! Make sure to .register!");
                                       break;
                                   }
                                   battling = false;
                               }

                           }
                       }
                   }
               });
        }

        private void DuelWeaponChoose()
        {
            int roll = rdm.Next(101);
            if (roll < 50)
            {
                weapon = "Sword";
                damage = 10;
            }
            else if (roll < 75)
            {
                weapon = "Fire Blast";
                damage = 20;
            }
            else if (roll < 80)
            {
                weapon = "Sick Judo Powers";
                damage = 30;
            }
            else
            {
                weapon = "Pistol";
                damage = 15;
            }
        }

        private void DuelAttack()
        {
            lenHealth -= damage;
        }

        private string DuelDisplayInfo()
        {
            return $"```( ͡° ͜ʖ ͡°)'s Health: {DuelHealthBar("Lenny")}```" + Environment.NewLine + $"```{fighter}'s Health: {DuelHealthBar("Player")}" +
                Environment.NewLine + $"[1] {weapon}" + Environment.NewLine + "[2] Defend```";

        }

        private string DuelHealthBar(string person)
        {
            string HealthBar = null;

            if (person == "Lenny")
            {
                if (lenHealth <= 0) HealthBar = "[          ]";
                else if (lenHealth < 10) HealthBar = "[|         ]";
                else if (lenHealth < 20) HealthBar = "[||        ]";
                else if (lenHealth < 30) HealthBar = "[|||       ]";
                else if (lenHealth < 40) HealthBar = "[||||      ]";
                else if (lenHealth < 50) HealthBar = "[|||||     ]";
                else if (lenHealth < 60) HealthBar = "[||||||    ]";
                else if (lenHealth < 70) HealthBar = "[|||||||   ]";
                else if (lenHealth < 80) HealthBar = "[||||||||  ]";
                else if (lenHealth < 90) HealthBar = "[||||||||| ]";
                else HealthBar = "[||||||||||]";
            }
            else if (person == "Player")
            {
                if (userHealth <= 0) HealthBar = "[          ]";
                else if (userHealth < 10) HealthBar = "[|         ]";
                else if (userHealth < 20) HealthBar = "[||        ]";
                else if (userHealth < 30) HealthBar = "[|||       ]";
                else if (userHealth < 40) HealthBar = "[||||      ]";
                else if (userHealth < 50) HealthBar = "[|||||     ]";
                else if (userHealth < 60) HealthBar = "[||||||    ]";
                else if (userHealth < 70) HealthBar = "[|||||||   ]";
                else if (userHealth < 80) HealthBar = "[||||||||  ]";
                else if (userHealth < 90) HealthBar = "[||||||||| ]";
                else HealthBar = "[||||||||||]";
            }

            return HealthBar;
        }
        #endregion

        private void registerCommand()
        {
            commands.CreateCommand("register")
                .Alias(new string[] { "reg" })
                .Description("Register yourself to my user list and start earning coins!")
                .Do(async (e) =>
               {
                   await e.Channel.SendMessage($"Adding {e.User.Name} to list.");

                   for (int i = 0; i > -1; i++)
                   {
                       if (set.users[i] == "0")
                       {
                           set.users[i] = e.User.Name;
                           set.coins[i] = 10;
                           set.owned[i] = set.users[i];
                           set.Save();
                           Console.WriteLine($"{e.User.Name} has registered!");
                           await e.Channel.SendMessage("Here's 10 Lenny Coins to start you off!");
                           break;
                       }
                       else if (set.users[i] == e.User.Name)
                       {
                           await e.Channel.SendMessage("You're already registered!");
                           break;
                       }
                   }


               });
        }

        private void profileCommand()
        {
            int uNum = -1;
            User uProf;

            commands.CreateCommand("profile")
                .Description("Displays a users profile")
                .Parameter("user", ParameterType.Unparsed)
                .Do(async (e) =>
               {
                   if (e.GetArg("user") == "")
                   {
                       uProf = e.User;

                       for (int i = 0; i > -1; i++)
                       {
                           if (set.users[i] == uProf.Name)
                           {
                               uNum = i;
                               break;
                           }
                           else if (set.users[i] == uProf.Nickname)
                           {
                               uNum = i;
                               break;
                           }
                           else if (set.users[i] == "0") break;

                       }

                       await e.Channel.SendMessage(uProf.Name + Environment.NewLine +
                           $"Lenny Coins: {set.coins[uNum]}" + Environment.NewLine +
                           $"Owned commands: {set.owned[uNum]}");

                   }
                   else
                   {
                       uProf = e.Server.FindUsers(e.GetArg("user"), false).FirstOrDefault();

                       if (uProf == null)
                       {
                           await e.Channel.SendMessage("User not found! If the user is *you*, please register using '.reg'.");
                       }
                       else
                       {
                           for (int i = 0; i > -1; i++)
                           {
                               if (set.users[i] == uProf.Name)
                               {
                                   uNum = i;
                                   break;
                               }
                               else if (set.users[i] == uProf.Nickname)
                               {
                                   uNum = i;
                                   break;
                               }
                               else if (set.users[i] == "0") break;

                           }

                           await e.Channel.SendMessage(uProf.Name + Environment.NewLine +
                               $"Lenny Coins: {set.coins[uNum]}" + Environment.NewLine +
                               $"Owned commands: {set.owned[uNum]}");

                       }
                   }



                   uNum = -1;
               });

        }

        private void consoleCommand()
        {
            commands.CreateCommand("console")
                .Description("Displays info in console")
                .Do(async (e) =>
               {

                   await e.Channel.SendMessage("Check console for server info!");


                   Console.WriteLine("#####PROFILES#####");
                   for (int i = 0; i <= 200; i++)
                   {
                       if (set.users[i] == "0") break;
                       Console.WriteLine("USER: " + set.users[i] + $"[{i}]");
                       Console.WriteLine("COINS: " + set.coins[i]);
                       Console.WriteLine("OWNED COMMANDS: " + set.owned[i]);
                       Console.WriteLine("------------------");
                   }
                   Console.WriteLine("##################");
                   Console.WriteLine($"Set game: {e.Server.FindUsers("( ͡° ͜ʖ ͡°)").FirstOrDefault().CurrentGame}");
                   Console.WriteLine("###OTHER THINGS###");
                   Console.WriteLine($"State: {discord.State} || Status: {discord.Status}");
                   Console.WriteLine("#####LEADERS#####");
                   string mostCoins = set.users[0];
                   int mostCoinsInt = set.coins[0];
                   for (int i = 0; i < 100; i++)
                   {
                       if (set.coins[i] > mostCoinsInt)
                       {
                           mostCoins = set.users[i];
                           mostCoinsInt = set.coins[i];
                       }
                   }
                   Console.WriteLine($"Most Lenny Coins: {mostCoins} with {mostCoinsInt} Lenny Coins!");

               });
        }

        private void eccCommand()
        {
            commands.CreateCommand("enableconsolechat")
                .Description("Enabled the ability to chat as Lenny from console.")
                .Alias(new string[] { "ecc" })
                .Do(async (e) =>
               {
                   await e.Channel.SendMessage("You may begin typing in console! ( ͡° ͜ʖ ͡°) Type '/stop' in console to stop.");
                   ecc = true;

                   while (ecc)
                   {
                       eccMessage = Console.ReadLine();
                       if (eccMessage == "/stop")
                       {
                           await e.Channel.SendMessage("Stopping .ecc, you may now use commands again.");
                           ecc = false;
                       }
                       else await e.Channel.SendMessage(eccMessage);
                   }


               });
        }

        private void lotteryCommand()
        {
            commands.CreateCommand("lottery")
                .Alias(new string[] { "lot" })
                .Description("Users enter, then the winner recieves the prize money! Parameters: [join] [info] [create (initial prize) (entry cost) (time *(minutes)*)]")
                .Parameter("arg", ParameterType.Optional)
                .Parameter("prize", ParameterType.Optional)
                .Parameter("cost", ParameterType.Optional)
                .Parameter("time", ParameterType.Optional)
                .Do(async (e) =>
               {
                   if (checkOwned(e.User, 11, e))
                   {
                       int userID = GetUserID(e.User);

                       if (e.GetArg("arg") == "join")
                       {
                           if (!lotteryOn)
                           {
                               await e.Channel.SendMessage("Sorry! No lottery on right now. Check later!");
                           }
                           else if (lotteryOn && set.inLottery[userID])
                           {
                               await e.Channel.SendMessage("You've already entered the lottery! Use '.lottery info' to view the lottery information!");
                           }
                           else
                           {
                               if (set.coins[userID] >= lotteryEntry)
                               {
                                   set.inLottery[userID] = true;
                                   lotteryPrize += lotteryEntry;
                                   set.coins[userID] -= lotteryEntry;
                                   await e.Channel.SendMessage("Successfully joined lottery!");
                               }
                               else await e.Channel.SendMessage($"Sorry! It costs {lotteryEntry} Lenny coins to enter this lottery. You have: {set.coins[userID]} Lenny coins!");
                           }
                       }
                       else if (e.GetArg("arg") == "info")
                       {
                           if (lotteryOn)
                           {
                               await e.Channel.SendMessage($"The current lottery ends at {lotteryEnd}! Join so you can win!{Environment.NewLine}*You miss 100% of the shots you don't take.* **-Sidney Crosby I think?**");
                           }
                           else await e.Channel.SendMessage("No lottery happening right now! Sorry!");
                       }
                       else if (e.GetArg("arg") == "create")
                       {
                           if (e.User.Name != "brady0423")
                           {
                               await e.Channel.SendMessage("Only Brady can create a lottery! ( ͡° ʖ̯ ͡°)");
                           }
                           else if (lotteryOn) await e.Channel.SendMessage("There is already a lottery going on! ( ͡° ʖ̯ ͡°)");
                           else
                           {
                               lotteryEnd = DateTime.Now.Add(new TimeSpan(0, Convert.ToInt32(e.GetArg("time")), 0));
                               lotteryPrize = Convert.ToInt32(e.GetArg("prize"));
                               lotteryEntry = Convert.ToInt32(e.GetArg("cost"));
                               lotChannel = e.Channel;
                               await e.Channel.SendMessage($"Lottery started! It costs {lotteryEntry} and the initial prize is {lotteryPrize} Lenny Coins, and it ends at {lotteryEnd}!");
                               lotteryOn = true;
                           }
                       }
                       else if (e.GetArg("arg") == "")
                       {
                           if (lotteryOn) await e.Channel.SendMessage($"Hey, {e.User.Nickname}! There's a lottery on right now! It ends at {lotteryEnd}.{Environment.NewLine}Use .lottery join to join for {lotteryEntry} Lenny Coins!" + Environment.NewLine +
                               $"The current pot is {lotteryPrize} Lenny Coins!");
                           else await e.Channel.SendMessage($"Hey, {e.User.Nickname}! Sorry, no lottery on right now. Check again later or wait for an announcement!");


                       }
                   }
               });
        }

        private void buyCommand()
        {
            commands.CreateCommand("buy")
                .Alias(new string[] { "b" })
                .Description("Buy things from the shop with Lenny coins!")
                .Parameter("item", ParameterType.Optional)
                .Do(async (e) =>
               {
                   int price = 0;
                   string id = "0";

                   if (e.GetArg("item") == "")
                   {
                       await e.Channel.SendMessage("Here's what you can buy! ( ͡° ͜ʖ ͡°) (Use .buy [item id#]! No brackets!)" + Environment.NewLine + Environment.NewLine +
                           "[1] .hello command! 1 Lenny coin!" + Environment.NewLine +
                           "[2] .say command! 2 Lenny coins!" + Environment.NewLine +
                           "[3] .sus command! 3 Lenny coins!" + Environment.NewLine +
                           "[4] .ask command! 5 Lenny coins!" + Environment.NewLine +
                           "[5] .roll comand! 5 Lenny coins!" + Environment.NewLine +
                           "[6] .meme command! 15 Lenny coins!" + Environment.NewLine +
                           "[7] .shook command! 5 Lenny coins!" + Environment.NewLine +
                           "[8] .talk command! 8 Lenny coins!" + Environment.NewLine +
                           "[9] .setGame command! 20 Lenny coins!" + Environment.NewLine +
                           "[10] .duel command! 50 Lenny coins!" + Environment.NewLine +
                           "[11] .lottery command! 5 Lenny coins!" + Environment.NewLine +
                           "[12] .kkk command! 5 Lenny coins!" + Environment.NewLine +
                           "[13] .beeMovie command! 1000 Lenny coins!" + Environment.NewLine +
                           "[14] .poll command! 200 Lenny coins! Buying this give you the ablity to make polls, you can already vote!" + Environment.NewLine +
                           "----------------Non-Commands-------------" + Environment.NewLine +
                           "[01] Custom Role! 200 Lenny coins! (Your own role with your choice of name and colour!)");
                   }
                   else
                   {

                       if (e.GetArg("item") == "1") price = 1;
                       else if (e.GetArg("item") == "2") price = 2;
                       else if (e.GetArg("item") == "3") price = 3;
                       else if (e.GetArg("item") == "4") price = 5;
                       else if (e.GetArg("item") == "5") price = 5;
                       else if (e.GetArg("item") == "6") price = 15;
                       else if (e.GetArg("item") == "7") price = 5;
                       else if (e.GetArg("item") == "8") price = 8;
                       else if (e.GetArg("item") == "9") price = 20;
                       else if (e.GetArg("item") == "10") price = 50;
                       else if (e.GetArg("item") == "11") price = 5;
                       else if (e.GetArg("item") == "12") price = 5;
                       else if (e.GetArg("item") == "13") price = 1000;
                       else if (e.GetArg("item") == "14") price = 2000;
                       else if (e.GetArg("item") == "01") price = 200;

                       else await e.Channel.SendMessage("Please enter a valid item number!");

                       id = e.GetArg("item");

                       if (price != 0)
                       {
                           for (int i = 0; i < 100; i++)
                           {
                               if (set.users[i] == e.User.Name)
                               {
                                   if (set.coins[i] >= price)
                                   {
                                       if (set.owned[i].Contains(" " + id))
                                       {
                                           await e.Channel.SendMessage("You already own this command!");
                                           break;
                                       }
                                       else
                                       {
                                           if (id == "01")
                                           {
                                               await e.Channel.SendMessage("Use the .role command to create your role, " + e.User.Name + "!");
                                               creatingRole[GetUserID(e.User)] = true;
                                           }
                                           else
                                           {
                                               set.owned[i] += $" {id} ";
                                           }
                                           set.coins[i] -= price;
                                           await e.Channel.SendMessage($"Your purchase was successful! You now have {set.coins[i]} Lenny coins!");
                                           set.Save();
                                           break;
                                       }
                                   }
                                   else
                                   {
                                       await e.Channel.SendMessage("Sorry! You can't afford this item.");
                                       break;
                                   }
                               }
                               else if (set.users[i] == "0")
                               {
                                   await e.Channel.SendMessage("Are you sure you're registered? Type .reg to register now!");
                                   break;
                               }
                           }

                       }
                   }
               });
        }

        private void coinCommand()
        {
            commands.CreateCommand("coin")
                .Description("Used by Brady to give people Lenny coins!")
                .Parameter("user", ParameterType.Required)
                .Parameter("amount", ParameterType.Required)
                .Do(async (e) =>
                {

                    if (e.User != e.Server.FindUsers("brady0423", false).FirstOrDefault()) await e.Channel.SendMessage("Nice try! ( ͡° ͜ʖ ͡°) Only Brady can do this.");
                    else
                    {
                        int amount = Convert.ToInt32(e.GetArg("amount"));
                        User reciever = e.Server.FindUsers(e.GetArg("user"), false).FirstOrDefault();
                        bool recieved = false;

                        for (int i = 0; i < 100; i++)
                        {
                            if (set.users[i] == reciever.Name)
                            {
                                set.coins[i] += amount;
                                await e.Channel.SendMessage($"{reciever.Name} has been given {amount} Lenny coins!");
                                recieved = true;
                                set.Save();
                                break;
                            }
                        }

                        if (!recieved) await e.Channel.SendMessage($"User {reciever} not found! Did you enter everything correctly? Is {reciever} registered?");
                    }
                });

        }

        private void kkkCommand()
        {
            commands.CreateCommand("kkk")
                .Description("GO BACK TO AFRICA, ZAIM!")
                .Do(async (e) =>
               {
                   if (checkOwned(e.User, 12, e))
                   {
                       await e.Channel.SendFile("commandPics/kkk.jpg");
                   }
               });



        }

        private void roleCommand()
        {
            commands.CreateCommand("role")
                .Description("Used after buying a role to create and edit it!")
                .Parameter("arg", ParameterType.Optional)
                .Parameter("name",ParameterType.Optional)
                .Parameter("colour",ParameterType.Optional)
                .Do(async (e) =>
               {
                   if (e.GetArg("arg") == "")
                   {
                       await e.Channel.SendMessage($"Hey, {e.User.Name}! Use this command to add/edit your role. (Parameters: [create (name) (colour)])");
                   }
                   else if (e.GetArg("arg") == "create")
                   {
                       if (creatingRole[GetUserID(e.User)] == true)
                       {
                           //Color color = e.GetArg("colour");
                           //await e.Server.CreateRole(name: e.GetArg("name"), color: e.GetArg("colour"));
                       }
                       else
                       {
                           await e.Channel.SendMessage("In order to create a role, you must buy it from the '.buy' shop!");
                       }
                   }
               });
        } //Not actually done oops

        private void beeMovieCommand()
        {
            commands.CreateCommand("beeMovie")
                .Alias(new string[] { "bm" })
                .Description("Sends random lines from BeeMovieScript.txt at random intervals in this chat.")
                .Parameter("add / del",ParameterType.Multiple)
                .Do(async (e) =>
               {
                   if (checkOwned(e.User, 13, e))
                   {
                       if (/*!set.*/bmOn == false)
                       {
                           await e.Channel.SendMessage("You'll regret this. ( ͡° ʖ̯ ͡°)");
                           sendDelay = new TimeSpan(0,0,1);
                           sendTime = DateTime.Now + sendDelay;
                           beeChannel = e.Channel;
                           /*set.*/bmOn = true;
                       }
                       else
                       {
                           await e.Channel.SendMessage("You've saved us. ( ͡° ͜ʖ ͡°)");
                           /*set.*/bmOn = false;
                       }

                   }
               });
        } //fix

        private void pollCommand()
        {
            commands.CreateCommand("poll")
                .Description("Creates a poll that users can vote on!")
                .Parameter("create/vote", ParameterType.Optional)
                .Parameter("title/choice", ParameterType.Optional)
                .Parameter("time",ParameterType.Optional)
                .Parameter("option1", ParameterType.Optional)
                .Parameter("option2", ParameterType.Optional)
                .Parameter("option3", ParameterType.Optional)
                .Parameter("option4", ParameterType.Optional)
                .Parameter("option5", ParameterType.Optional)
                .Do(async (e) =>
               {
                   if (e.GetArg("create/vote") == "create")
                   {
                       if (checkOwned(e.User, 14, e))
                       {
                           if (!pollOn)
                           {
                               #region Reset Poll Values
                               for (int i = 1; i <= 5; i++)
                               {
                                   pollOption[i] = null;
                                   pollOptionVotes[i] = 0;
                                   pollTotalVotes = 0;
                               }

                               for (int i = 0; i < 100; i++)
                               {
                                   pollUserVoted[i] = false;
                               }
                                    #endregion
                                    pollChannel = e.Channel;
                               pollOn = true;
                               pollDuration = new TimeSpan(0, Convert.ToInt32(e.GetArg("time")), 0);
                               pollEnd = DateTime.Now + pollDuration;
                               for (int i = 1; i < 6; i++)
                               {
                                   if (e.GetArg("option" + i) == "") break;
                                   else
                                   {
                                       itemNum = i;
                                       pollOption[i] = e.GetArg("option" + i);
                                   }
                               }
                               pollTitle = e.GetArg("title/choice");
                               poll = "POLL: " + pollTitle;

                               for (int i = 1; i < itemNum + 1; i++)
                               {
                                   poll += Environment.NewLine + $"`[{i}] {pollOption[i]}`";
                               }
                               poll += Environment.NewLine + "Vote now using '.poll vote [#]'!";

                               await e.Channel.SendMessage(poll);
                           }
                           else
                           {
                               await e.Channel.SendMessage("There is already a poll on!");
                           }
                       }
                   }
                   else if (e.GetArg("create/vote") == "vote")
                   {
                       if (Convert.ToInt32(e.GetArg("title/choice")) > itemNum)
                       {
                           await e.Channel.SendMessage("Please input a valid choice number!");
                       }
                       else
                       {
                           if (pollUserVoted[GetUserID(e.User)])
                           {
                               await e.Channel.SendMessage("You have already voted in this poll!");
                           }          
                           else
                           {
                               pollUserVoted[GetUserID(e.User)] = true;
                               pollOptionVotes[Convert.ToInt32(e.GetArg("title/choice"))]++;
                               pollTotalVotes++;
                               await e.Channel.SendMessage(displayPoll());
                           }
                       }
                   }
                   else await e.Channel.SendMessage($"----------------------------Usage---------------------------- {Environment.NewLine} Creating: `.poll create [title] [time (min)] [option1] [option2] ... [option5]` {Environment.NewLine} Seperate items with spaces! If items have spaces in them, use quotations. {Environment.NewLine}" +
                       "Voting: `.poll vote [option#]`" + Environment.NewLine + 
                       "-----------------------CURRENT POLL----------------------" + Environment.NewLine + displayPoll());
               });
        }

        private void memeCommand()
        {
            commands.CreateCommand("meme")
                .Description("Sends a random meme! LOL ECKSEE I'M SO RANDOM!")
                .Alias(new string[] { "mem", "m" })
                .Do(async (ecc) =>
               {

               });
        } //finish

        private void submitMemeCommand()
        {
            commands.CreateCommand("submitMeme")
                .Alias(new string[] { "sm" })
                .Description("Submits a meme for Lenny to review, then offers you Lenny Coins for them!")
                .Parameter("view",ParameterType.Optional) //need parameter to allow penders
                .Parameter("next / accept / deny",ParameterType.Optional)
                .Parameter("offer", ParameterType.Optional)
                .Do(async (e) =>
                {
                    User submitter = null;
                    int offer = 0;
                    int memeNumber = 0;
                    if (e.GetArg("view") == "view")
                    {
                        
                        if (e.GetArg("next / accept / deny") == null)
                        {
                            if (e.User != e.Server.FindUsers("brady0423", false).FirstOrDefault())
                            {
                                await e.Channel.SendMessage("*Only the memelord can view and approve of submitted memes!");
                            }

                            else
                            {
                                List<int> memeChecks = new List<int>();
                                for (int i = 0; i <= 1000; i++)
                                {
                                    if (!File.Exists($"pendingMemes/meme{i}.jpg")) memeChecks.Add(i);
                                }

                                await e.Channel.SendMessage($"Sending pending meme {memeNumber}...");
                                await e.Channel.SendFile($@"C:\Users\Owner\Documents\Visual Studio 2015\Projects\LennyBot\LennyBot\pendingMemes\meme{memeNumber}.jpg");
                            }
                        }
                        else if (e.GetArg("next / accept / deny") == "next")
                        {
                            memeNumber++;
                            await e.Channel.SendMessage($"Sending pending meme {memeNumber}...");
                            await e.Channel.SendFile($@"C:\Users\Owner\Documents\Visual Studio 2015\Projects\LennyBot\LennyBot\pendingMemes\meme{memeNumber}.jpg");
                        }
                        else if (e.GetArg("next / accept / deny") == "accept")
                        {
                            offer = Convert.ToInt32(e.GetArg("offer"));
                            submitter = e.Server.FindUsers(set.users[set.memeSubmitter[memeNumber]]).FirstOrDefault();
                            await e.Channel.SendMessage($"@{submitter}, you have been offered {offer} lenny coins for this meme. Do you accept? `.sm y` or `.sm n`.");
                        }
                    }
                    else if (e.GetArg("view") == "y")
                    {
                        if (e.User == submitter)
                        {
                            await e.Channel.SendMessage($"Thanks! You've been given {offer} Lenny coins and the meme has been added to .meme!");
                            set.coins[set.memeSubmitter[memeNumber]] += offer;
                            //Make it actually get added to the meme command
                        }
                        else await e.Channel.SendMessage($"Only {submitter} can accept this offer!");
                    }
                    else if (e.GetArg("view") == "n")
                    {
                        if (e.User == submitter)
                        {
                            await e.Channel.SendMessage($"Offer denied.");
                        }
                        else await e.Channel.SendMessage($"Only {submitter} can deny this offer!");
                    }
                    else
                    {
                        string fileName = null;
                        if (e.Message.Attachments == null) await e.Channel.SendMessage("You must include an image meme with your message!");
                        else
                        {
                            Message.Attachment meme;
                            meme = e.Message.Attachments[0];

                            for (int i = 0; i <= 1000; i++)
                            {
                                if (!File.Exists($@"C:\Users\Owner\Documents\Visual Studio 2015\Projects\LennyBot\LennyBot\pendingMemes\meme{i}.jpg"))
                                {
                                    fileName = $"meme{i}.jpg";
                                    set.memeSubmitter[i] = GetUserID(e.User);
                                    break;
                                }

                            }
                            webClient.DownloadFile(meme.Url, $@"C:\Users\Owner\Documents\Visual Studio 2015\Projects\LennyBot\LennyBot\pendingMemes\{fileName}");
                            Console.WriteLine($"Meme submitted by {e.User.Name}!");
                            await e.Channel.SendMessage($"Meme recieved! Thanks, {e.User.Nickname}!");
                        }
                    }

                });
        }

        private void giveCoinsCommand()
        {
            commands.CreateCommand("giveCoins")
                .Description("Give Lenny Coins to another user!")
                .Alias(new string[] { "gc" })
                .Parameter("user", ParameterType.Required)
                .Parameter("amount", ParameterType.Required)
                .Do(async (e) =>
               {
                   int amount = Convert.ToInt32(e.GetArg("amount"));
                   User reciever = e.Server.FindUsers(e.GetArg("user")).FirstOrDefault();
                   User giver = e.User;
                   if (reciever == null) await e.Channel.SendMessage("User not found!");
                   else if (reciever == giver) await e.Channel.SendMessage("You can't give yourself coins!");
                   else
                   {
                       if (amount < 1) await e.Channel.SendMessage("Please enter a number above 0!");
                       else if (amount > set.coins[GetUserID(e.User)]) await e.Channel.SendMessage("You don't have that many coins!");
                       else
                       {
                           int rID = GetUserID(reciever);
                           int gID = GetUserID(giver);

                           set.coins[rID] += amount;
                           set.coins[gID] -= amount;

                           await e.Channel.SendMessage($"Transfer successful! {amount} coins sent from {giver.Nickname} to {reciever.Nickname}!");
                       }
                   }
               });
        }

        private void eggBongoCommand()
        {
            commands.CreateCommand("eggBongo")
                .Alias(new string[] { "eb" })
                .Description("ONLY THOSE WORTHY MAY USE THIS.")
                .Parameter("user", ParameterType.Optional)
                .Do(async (e) =>
               {
                   //if (e.GetArg("user") == null)
                   //{
                       if (e.User.Id == 153966208968949760)
                       {
                           await e.Channel.SendFile("commandPics/eggbongo.jpg");
                       }
                       else await e.Channel.SendMessage("NO");
                   //}
               });
        }

        private void imageCommand()
        {
            commands.CreateCommand("image")
                .Description("Searches for an image then sends it into the chat!")
                .Parameter("search", ParameterType.Required)
                .Do(async (e) =>
               {
                   string search = e.GetArg("search");
                   await e.Channel.SendMessage($"Searching for {search}...");


               });
        }
        //      Command ID's:      |      Other Item ID's
        //                         |
        //      hello 1            |       upgrade role 01
        //      say 2              |
        //      sus 3              |
        //      ask 4              |
        //      roll 5             |
        //      meme 6             |
        //      shook 7            |
        //      talk 8             |
        //      setGame 9          |
        //      duel 10            |
        //      lottery 11         |
        //      kkk 12             |
        //      beeMovie 13        |
        //      poll 14            |
        //
        // IF COMMAND IS NOT ON LIST, USERS HAVE IT BY DEFAULT (Or it just can't be bought).



        #region Cool Functions

        private bool checkOwned(User user, int id, CommandEventArgs e)
        {
            if (e.User == e.Server.FindUsers("Brent Bott", false))
            {
                e.Channel.SendMessage("Nice try, Brent.");
                return false;
            }
            else
            {
                for (int i = 0; i < 100; i++)
                {
                    if (set.users[i] == user.Name)
                    {
                        if (set.owned[i].Contains($" {id}"))
                        {
                            return true;
                        }
                        else
                        {
                            e.Channel.SendMessage("You don't own this command! Use .buy to purchase it.");
                            return false;
                        }
                    }
                }
                e.Channel.SendMessage("You're not registered! Make sure to register using .reg!");
                return false;
            }
        }

        private static string displayPoll()
        {
            string poll = "```POLL: " + pollTitle;

            for (int i = 1; i<=itemNum; i++)
            {
                poll += Environment.NewLine + makeBar(pollOptionVotes[i], pollTotalVotes) + $" [{i}] " + pollOption[i];
            }
            if (pollOn) poll += Environment.NewLine + "Vote now using '.poll vote [#]'!```";


            return poll;
        }

        private static string makeBar(decimal number, decimal total)
        {
            decimal percentage = (number / total) * 10;
            int num = Convert.ToInt32(Math.Round(percentage));
            string bar = "[";
            for (int i = 1; i<=num; i++)
            {
                bar += "|";
            }

            int n = 1;
            while (n++ <= (10 - num))
            {
                bar += " ";
            }
            bar += "]";
            return bar;
        }

        private static void TimerCallback(object o)
        {
            #region Lottery
            if (lotteryOn)
            {
                if (DateTime.Now > lotteryEnd)
                {
                    lotteryOn = false;
                    lotChannel.SendMessage("The lottery has ended!"); //Adjust
                    List<int> lotteryEntrants = new List<int>();

                    for (int i = 0; i < 50; i++)
                    {
                        if (set.inLottery[i])
                        {
                            set.inLottery[i] = false;
                            lotteryEntrants.Add(i);
                        }
                    }

                    IEnumerable<int> winner = lotteryEntrants.OrderBy(x => rdm.Next());
                    if (winner.Count() == 0) lotChannel.SendMessage("No one entered! ( ͡° ʖ̯ ͡°) I guess the money will go to charity.");
                    else
                    {
                        int winnerID = winner.First();
                        lotChannel.SendMessage($"The winner is, {set.users[winnerID]}! Congratulations! You've won {lotteryPrize} Lenny coins!");
                        set.coins[winnerID] += lotteryPrize;
                    }
                }
            }
            #endregion

            #region Sleep ( ͡° ʖ̯ ͡°)
            //if (dateNow.DayOfWeek == DayOfWeek.Friday || dateNow.DayOfWeek == DayOfWeek.Saturday || dateNow.DayOfWeek == DayOfWeek.Sunday)
            //{
            //
            //}
            //else
            //{
            //    if (DateTime.Now > lennySleep && alertLevel == 0)
            //    {
            //        general.SendMessage("LennyBot will be sleeping in *10 minutes*! Get any commands out of the way now!");
            //        alertLevel++;
            //    }
            //    else if (DateTime.Now > lennySleep2 && alertLevel == 1)
            //    {
            //        general.SendMessage("LennyBot will be sleeping in *1 minute*! Say goodnight!");
            //        alertLevel++;
            //    }
            //    else if (DateTime.Now > lennySleep3 && alertLevel == 2)
            //    {
            //        general.SendMessage("Goodnight! ( ͡° ͜ʖ ͡°) ");
            //        alertLevel++;
            //    }
            //    else if (alertLevel == 3)
            //    {
            //        Console.WriteLine("SHUTTING DOWN...");
            //        discord.Disconnect(); //Test this.
            //    }
            //}
            #endregion

            #region Bee Movie
            if (/*set.*/bmOn)
            {
                if (DateTime.Now > sendTime)
                {
                    beeChannel.SendMessage(beeScript[rdm.Next(beeScript.Length)]);
                    sendDelay = new TimeSpan(rdm.Next(1), rdm.Next(60), rdm.Next(60));
                    sendTime = DateTime.Now + sendDelay;
                }
            }


            #endregion

            #region Poll
            if (pollOn && DateTime.Now > pollEnd)
            {
                int highestVotes = 0;
                int highestVote = -1;
                for (int i = 1; i <= 5; i++)
                {
                    if (pollOptionVotes[i] > highestVotes)
                    {
                        highestVotes = pollOptionVotes[i];
                        highestVote = i;
                    }
                }
                pollChannel.SendMessage("The poll has ended!" + Environment.NewLine +
                    $"The winner is: `{pollOption[highestVote]}` with `{highestVotes}` votes!");
                pollOn = false;
                
                pollChannel.SendMessage(displayPoll() + "```");
            }
            #endregion

            set.Save();
            GC.Collect();
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
//            Console.WriteLine("Dicks");
        }

        private int GetUserID(User user)
        {
            for (int i = 0; i<100;i++)
            {
                if (set.users[i] == user.Name || set.users[i] == user.Nickname)
                {
                    return i;
                }
            }
            return -1;
        }

        #endregion

        private void Log(Object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
            discord.SetGame(set.setGame);
            //set.beeChannel = discord.FindServers("Brady Bunch").FirstOrDefault().FindChannels("theshittiestofposts", exactMatch: false).FirstOrDefault();
                }

    }
}


//  REMEMBER: 
//          sync to github
//          give people more reasons to use him
//          Finish .duel system (X) Incomplete, add more random events and choices
//          Add more to 'Profiles' (role, etc)
//              Keep bein' cool ( ͡° ͜ʖ ͡°)
//          fix .bm, set set.beeChannel properly (temp fixed)
