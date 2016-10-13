using Discord;
using Discord.Commands;

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LennyBot
{
    class MyBot
    {
        Timer t = new Timer(TimerCallback, null, 0, 2000);
        DiscordClient discord;
        static CommandService commands;
        Random rdm = new Random();
        string weapon;
        int damage;
        int lenHealth = 100;
        int userHealth = 100;
        string fighter;
        bool ecc = false;
        string eccMessage;
        static DateTime lotteryEnd;
        bool lotteryOn = false;
        static bool LotteryFin = false;
        

        static Properties.Settings set = new Properties.Settings();

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
            memeCommand();
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
            #endregion

            discord.ExecuteAndWait(async () =>
            {
                try
                {
                    await discord.Connect("NICE TRY", TokenType.Bot);
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
                    if (checkOwned(e.User, 2,e))
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
                .Alias(new string[] { "s"})
                .Do(async (e) =>
                {
                    if (checkOwned(e.User, 3,e))
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
                    if (checkOwned(e.User, 4,e))
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
                .Parameter("num",ParameterType.Required)
                .Do(async (e) =>
               {
                   if (checkOwned(e.User, 5,e))
                   {
                       int roll = rdm.Next(Convert.ToInt32(e.GetArg("num")));
                       await e.Channel.SendMessage(Convert.ToString(roll + 1));
                   }
               });
        }

        private void memeCommand()
        {
            commands.CreateCommand("meme")
                .Description("Picks a random meme and sends it")
                .Alias(new string[] { "mem", "m" })
                .Do(async (e) =>
                {
                    if (checkOwned(e.User, 6,e))
                    {
                        int picRoll = rdm.Next(77);
                        await e.Channel.SendFile($"pics/{picRoll}.png");
                    }
                });
        }

        private void shookCommand()
        {
            commands.CreateCommand("shook")
                .Description("Get shook")
                .Do(async (e) =>
                {
                    if (checkOwned(e.User, 7,e))
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
                   if (checkOwned(e.User, 8,e))
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
                .Description("Sets my 'Playing <game>'")
                .Parameter("game", ParameterType.Unparsed)
                .Do(async (e) =>
               {
                   if (checkOwned(e.User, 9,e))
                   {
                       await e.Channel.SendMessage($"Game updated to {e.GetArg("game")} ");
                       discord.SetGame(e.GetArg("game"));
                   }
                   
               });

        }

        #region Duel Functions
        private void duelCommand()
        {
            bool battling = false;
            fighter = null;
            

            commands.CreateCommand("duel")
                .Alias(new string[] { "d"})
                .Description("Fight me for Lenny Coins!")
                .Parameter("choice",ParameterType.Unparsed)
                .Do(async (e) =>
               {
                   if (checkOwned(e.User, 10,e))
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

            commands.CreateCommand("profile")
                .Description("Displays a users profile")
                .Parameter("user", ParameterType.Unparsed)
                .Do(async (e) =>
               {
                   //if (e.GetArg("user") == "")
                   //{
                       User uProf = e.User;
                   //}
                   //else
                   //{
                   //    User uProf = e.Channel.Users.                   }

                   for (int i = 0; i > -1; i++)
                   {
                       if (set.users[i] == uProf.Name)
                       {
                           uNum = i;
                           break;
                       }
                       else if (set.users[i] == "0") break;
                           
                   }

                   if (uNum == -1) await e.Channel.SendMessage("User not found! If the user is *you*, please register using '.reg'.");
                   else await e.Channel.SendMessage(uProf.Name + Environment.NewLine +
                       $"Lenny Coins: {set.coins[uNum]}" + Environment.NewLine +
                       $"Owned commands: {set.owned[uNum]}");

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
                       Console.WriteLine("USER: " + set.users[i]);
                       Console.WriteLine("COINS: " + set.coins[i]);
                       Console.WriteLine("------------------");
                   }
                   Console.WriteLine("##################");
                   Console.WriteLine($"Set game: {discord.CurrentUser.CurrentGame}");
                   Console.WriteLine("###OTHER THINGS###");
                   Console.WriteLine($"State: {discord.State} || Status: {discord.Status}");
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
                .Description("Users enter, then the winner recieves the prize money!")
                .Parameter("arg",ParameterType.Required)
                .Parameter("join, info, create",ParameterType.Multiple)
                .Do(async (e) =>
               {
                   if (checkOwned(e.User, 11,e))
                   {
                       if (e.GetArg("arg") == "join")
                       {
                           await e.Channel.SendMessage("testJ");
                       }
                       else if (e.GetArg("arg") == "info")
                       {
                           if (lotteryOn)
                           {
                               await e.Channel.SendMessage("testI");
                           }
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
                               lotteryEnd = DateTime.Now.Add(new TimeSpan(0, 0, 10)); // Change to 0, 30, 0
                               await e.Channel.SendMessage($"Lottery started! Ends at {lotteryEnd}!");
                               lotteryOn = true;
                           }
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
                   int id = 0;

                   if (e.GetArg("item") == "")
                   {
                       await e.Channel.SendMessage("Here's what you can buy! ( ͡° ͜ʖ ͡°) (Use .buy [#]!)" + Environment.NewLine + Environment.NewLine +
                           "[1] .hello command! - 1 Lenny coin!" + Environment.NewLine +
                           "[2] .say command! - 2 Lenny coins!" + Environment.NewLine +
                           "[3] .sus command! - 3 Lenny coins!" + Environment.NewLine +
                           "[4] .ask command! - 5 Lenny coins!" + Environment.NewLine +
                           "[5] .roll comand! - 5 Lenny coins!" + Environment.NewLine +
                           "[6] .meme command! - 15 Lenny coins!" + Environment.NewLine +
                           "[7] .shook command! - 5 Lenny coins!" + Environment.NewLine +
                           "[8] .talk command! - 8 Lenny coins!" + Environment.NewLine +
                           "[9] .setGame command! - 20 Lenny coins!" + Environment.NewLine +
                           "[10] .duel command! - 50 Lenny coins!" + Environment.NewLine +
                           "[11] .lottery command! - 25 Lenny coins!");
                   }
                   else
                   {
                       id = Convert.ToInt32(e.GetArg("item"));

                       if (e.GetArg("item") == "1")
                       {
                           price = 1;
                       }
                       else if (e.GetArg("item") == "2")
                       {
                           price = 2;
                       }
                       else if (e.GetArg("item") == "3")
                       {
                           price = 3;
                       }
                       else if (e.GetArg("item") == "4")
                       {
                           price = 5;
                       }
                       else if (e.GetArg("item") == "5")
                       {
                           price = 5;
                       }
                       else if (e.GetArg("item") == "6")
                       {
                           price = 15;
                       }
                       else if (e.GetArg("item") == "7")
                       {
                           price = 5;
                       }
                       else if (e.GetArg("item") == "8")
                       {
                           price = 8;
                       }
                       else if (e.GetArg("item") == "9")
                       {
                           price = 20;
                       }
                       else if (e.GetArg("item") == "10")
                       {
                           price = 50;
                       }
                       else if (e.GetArg("item") == "11")
                       {
                           price = 25;
                       }
                       else await e.Channel.SendMessage("Please enter a valid item number!");

                       if (price != 0)
                       {
                           for (int i = 0; i < 100; i++)
                           {
                               if (set.users[i] == e.User.Name)
                               {
                                   if (set.coins[i] >= price)
                                   {
                                       set.owned[i] += $" {id} ";
                                       set.coins[i] -= price;
                                       await e.Channel.SendMessage($"Your purchase was successful! You now have {set.coins[i]} Lenny coins!");
                                       set.Save();
                                       break;
                                   }
                                   else
                                   {
                                       await e.Channel.SendMessage("Sorry! You can't afford this item.");
                                       break;
                                   }
                               }
                               await e.Channel.SendMessage("Are you sure you're registered? Type .reg to register now!");
                           }
                           
                       }
                   }
               });
        }

        private void coinCommand()
        {
            commands.CreateCommand("coin")
                .Description("Used by Brady to give people Lenny coins!")
                .Parameter("amount",ParameterType.Required)
                .Parameter("user", ParameterType.Required)
                .Do(async (e) =>
                {
                    if (e.User != e.Server.FindUsers("Brady", false)) await e.Channel.SendMessage("Nice try! ( ͡° ͜ʖ ͡°) Only Brady can do this.");
                    else
                    {
                        int amount = Convert.ToInt32(e.GetArg("amount"));
                        User reciever = (User)e.Server.FindUsers(e.GetArg("user"), false);
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


//      Command ID's:
//
//      hello - 1
//      say - 2
//      sus - 3
//      ask - 4
//      roll - 5
//      meme - 6
//      shook - 7
//      talk - 8
//      setGame - 9
//      duel - 10
//      lottery - 11
//
// IF COMMAND IS NOT ON LIST, USERS HAVE IT BY DEFAULT.




        private bool checkOwned(User user, int id, CommandEventArgs e)
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

        private static void TimerCallback(object o)
        {
            if (DateTime.Now > lotteryEnd)
            {
                LotteryFin = true;
            }
            set.Save();
            GC.Collect();
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
//            Console.WriteLine("Dicks");
        }

        private void Log(Object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

    }
}


//  REMEMBER: 
//          Test .coin command. Make sure input order is correct and figure that shiz out yo
//          Finish .duel system (X) Incomplete, add more random events and choices
//          Add more to 'Profiles' (( ͡° ͜ʖ ͡°), etc)
//          Add option to check profile of other user using .profile - Possibly using e.Server.FindUsers(user, bool);
//              Keep bein' cool ( ͡° ͜ʖ ͡°)
