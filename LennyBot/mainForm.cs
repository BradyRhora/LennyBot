using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Discord;
using Discord.Commands;

namespace LennyBot
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        #region Variables

        List<Server> servers = new List<Server>();
        List<Channel> channels = new List<Channel>();
        List<User> users = new List<User>();
        Server selectedServer;
        Channel selectedChannel;
        public static TimeSpan bmRemaining = new TimeSpan();
        User selectedUser;
        Properties.Settings set = new Properties.Settings();
        string[] user = new string[100];
        int selectedUserID;
        int threadCount;
        Random rdm = new Random();
        bool attemptConnect = true;
        #endregion

        private void Main(string[] args)
        {
            EventHandler<MessageEventArgs> handler = new EventHandler<MessageEventArgs>(MessageRecieved);
            MyBot.discord.MessageReceived += handler;

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtSubmit.Text.StartsWith("."))
            {
                string command = txtSubmit.Text;


                if (command.StartsWith(".help"))
                {
                    Log("Commands:");
                    Log("'.death' No.. Please no....");
                }
                else if (command.StartsWith(".death"))
                {
                    if (selectedServer.Id == 195670713183633408)
                    {
                        if (selectedChannel.GetUser(234726019884515331).Status == Discord.UserStatus.Online) selectedChannel.SendMessage("~echo .say ~echo .say ~echo ( ͡° ͜ʖ ͡°) ( ͡° ͜ʖ ͡°) .say ( ͡° ͜ʖ ͡°)");
                        else Log("Brent Bott must be online for this to work!");
                    }
                    else Log("You must be in the Brady Bunch server for this!");
                }



                txtSubmit.Text = null;
            }
            else
            {
                if (cbxServers.Text == "" || cbxServers.Text == null)
                {
                    txtConsole.Text += Environment.NewLine + "Please choose a server!";
                }
                else
                {
                    if (txtSubmit.Text == "") Log("Text cannot be blank!");
                    else
                    {
                        Log("LennyBot: " + txtSubmit.Text);
                        selectedChannel.SendMessage(txtSubmit.Text);
                        txtSubmit.Text = null;
                    }
                }
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Log("Server information loaded!");
            servers = MyBot.discord.Servers.ToList();
            for (int i = 0; i<servers.Count;i++)
            {
                cbxServers.Items.Add(servers[i]);
            }
            selectedServer = servers[0];
            cbxServers.SelectedIndex = 0;
            txtSetGame.Text = set.setGame;

            updateUsers();
            
        }

        private void cbxServers_SelectedValueChanged(object sender, EventArgs e)
        {
            cbxChannels.Items.Clear();
            selectedServer = servers[cbxServers.SelectedIndex];
            channels = selectedServer.TextChannels.ToList();
            updateUsers();

            for (int i = 0; i < channels.Count; i++)
            {
                cbxChannels.Items.Add(channels[i]);
            }
            cbxChannels.SelectedIndex = 0;
        }

        private void cbxChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedChannel = channels[cbxChannels.SelectedIndex];
        }
        
        private void Log(string text)
        {
            txtConsole.AppendText(Environment.NewLine + text);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            set.setGame = txtSetGame.Text;
            MyBot.discord.SetGame(txtSetGame.Text);

            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtConsole.Clear();
        }

        private void updateUsers()
        {
            cbxUsers.Items.Clear();
            users = selectedServer.Users.ToList();
            for (int i = 0; i < users.Count; i++)
            {
                cbxUsers.Items.Add(users[i]);
            }
            cbxUsers.SelectedIndex = 0;

            for (int i = 0; i<100; i++)
            {
                if (set.users[i] == selectedUser.Name)
                {
                    selectedUserID = i;
                    break;
                }
                else if (set.users[i] == "0") 
                {
                    selectedUserID = 0;
                    break;
                }
            }

            txtCoins.Text = Convert.ToString(set.coins[selectedUserID]);

            txtUserRole.Text = null;
            Role[] selectedUserRoles = selectedUser.Roles.ToArray();
            for (int i = 0; i < selectedUserRoles.Count();i++)
            {
                txtUserRole.Text += Environment.NewLine + selectedUserRoles[i];
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (MyBot.discord.State == Discord.ConnectionState.Connected)
            {
                btnConnect.Text = "Connect";
                MyBot.discord.Disconnect();
            }
            else
            {
                btnConnect.Text = "disonnect";
                Thread newThread = new Thread(new ThreadStart(connectBot));
                threadAdded();
                newThread.Start();
            }
        }

        [STAThread]
        private void connectBot()
        {
            MyBot MyBot = new MyBot();
        }

        private void timGetConsole_Tick(object sender, EventArgs e)
        {
            if (MyBot.consoleSend != null)
            {
                Log(MyBot.consoleSend);
                MyBot.consoleSend = null;
            }
        }

        private void MessageRecieved(object sender, EventArgs e)
        {
            Log("Message recieved!");
        }

        private void timLoad_Tick(object sender, EventArgs e)
        {
            try
            {
                servers = MyBot.discord.Servers.ToList();
                for (int i = 0; i < servers.Count; i++)
                {
                    cbxServers.Items.Add(servers[i]);
                }
                selectedServer = servers[0];
                cbxServers.SelectedIndex = 0;
                txtSetGame.Text = set.setGame;

                updateUsers();
                timLoad.Enabled = false;
                Log("Server information loaded!");
            }
            catch (Exception a)
            {
                Log("Unable to load server information! Trying again...");
                Log($"Error: {a}");
            }
        }

        private void cbxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedUser = users[cbxUsers.SelectedIndex];

            for (int i = 0; i < 100; i++)
            {
                if (set.users[i] == selectedUser.Name || set.users[i] == selectedUser.Nickname)
                {
                    selectedUserID = i;
                    txtCoins.Text = Convert.ToString(set.coins[selectedUserID]);
                    break;
                }
                else if (set.users[i] == "0")
                {
                    selectedUserID = 0;
                    txtCoins.Text = "UNREGISTERED";
                    break;
                }
            }


            txtUserRole.Text = null;
            Role[] selectedUserRoles = selectedUser.Roles.ToArray();
            for (int i = 0; i < selectedUserRoles.Count(); i++)
            {
                txtUserRole.Text += Environment.NewLine + selectedUserRoles[i];
            }
        }

        private void threadAdded()
        {
            threadCount++;
            lblRestartCount.Text = $"Restart Count: {threadCount}";
            lblRestartCount.Visible = true;
            if (threadCount < 5) lblRestartCount.ForeColor = System.Drawing.Color.Green;
            else
            {
                lblRestartCount.ForeColor = System.Drawing.Color.Green;
                lblRestartCount.Text += " Warning! High thread level. Consider restarting to clear threads.";
            }
        }

        private void btnBeeMovieSwitch_Click(object sender, EventArgs e)
        {
            if (MyBot.bmOn)
            {
                MyBot.bmOn = false;
                txtBeeMovie.ForeColor = System.Drawing.Color.Red;
                txtBeeMovie.Text = "DISABLED";
                btnBeeMovieSwitch.Text = "Enable";
                txtBMTime.Visible = false;
                selectedChannel.SendMessage("Bee Movie disabled.");
            }
            else
            {
                MyBot.bmOn = true;
                txtBeeMovie.ForeColor = System.Drawing.Color.Green;
                txtBeeMovie.Text = "ENABLED";
                btnBeeMovieSwitch.Text = "Disable";
                MyBot.beeChannel = selectedChannel;
                MyBot.sendDelay = new TimeSpan(rdm.Next(1), rdm.Next(60), rdm.Next(60));
                MyBot.sendTime = DateTime.Now + MyBot.sendDelay;
                selectedChannel.SendMessage("Bee Movie enabled.");
                txtBMTime.Text = string.Format("{0}:{1}:{2}", bmRemaining.Hours.ToString("00"), bmRemaining.Minutes.ToString("00"), bmRemaining.Seconds.ToString("00"));
                txtBMTime.Visible = true;
                
                timBM.Enabled = true;
            }
        }

        private void timBM_Tick(object sender, EventArgs e)
        {
            bmRemaining = MyBot.sendTime.Subtract(DateTime.Now);
            txtBMTime.Text = string.Format("{0}:{1}:{2}", bmRemaining.Hours.ToString("00"), bmRemaining.Minutes.ToString("00"), bmRemaining.Seconds.ToString("00"));
        }

        private void timDisconnectCheck_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i <= 5; i++)
            {
                if (MyBot.discord.State == Discord.ConnectionState.Disconnected)
                {
                    if (attemptConnect)
                    {
                        attemptConnect = false;
                        Log($"LennyBot unexpectedly disconnected! Attempting to reconnect... Attempt {i}");
                        Thread newThread = new Thread(new ThreadStart(connectBot));
                        threadAdded();
                        newThread.Start();
                        timDCWait.Start();
                    }
                }
                else break;

                if (i > 5)
                {
                    Log("Unable to connect! Check your internet connection and restart LennyBot.");
                    timDisconnectCheck.Stop();
                }
            }
        }

        private void timDCWait_Tick(object sender, EventArgs e)
        {
            attemptConnect = true;
            timDCWait.Stop();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

//NOTES:
//      Make button for .console