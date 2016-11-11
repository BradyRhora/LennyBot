using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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



        private void mainForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Don't forget to click load!");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
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

        private void btnLoad_Click(object sender, EventArgs e)
        {
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
            selectedUser = users[cbxUsers.SelectedIndex];

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
                MyBot MyBot = new MyBot();
            }
        }
    }
}

//NOTES:
//      - Make it so that messages that are sent in the selected channel get recieved into txtConsole! If you can.
//      - Messages are being sent to the wrong server but right channel? Fix!