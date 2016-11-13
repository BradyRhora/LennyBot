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
        User selectedUser;
        Properties.Settings set = new Properties.Settings();
        string[] user = new string[100];
        int selectedUserID;

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
                    Log("LennyBot: " + txtSubmit.Text);
                    selectedChannel.SendMessage(txtSubmit.Text);
                    txtSubmit.Text = null;
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
            txtConsole.Text += Environment.NewLine + text;
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
                    Log("User is not registered!");
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
                    Log("User is not registered!");
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
    }
}

//NOTES: