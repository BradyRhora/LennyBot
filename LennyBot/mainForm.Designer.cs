namespace LennyBot
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.txtSubmit = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbxServers = new System.Windows.Forms.ComboBox();
            this.cbxChannels = new System.Windows.Forms.ComboBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblChannel = new System.Windows.Forms.Label();
            this.lblSetGame = new System.Windows.Forms.Label();
            this.txtSetGame = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblUsers = new System.Windows.Forms.Label();
            this.cbxUsers = new System.Windows.Forms.ComboBox();
            this.lblCoins = new System.Windows.Forms.Label();
            this.txtCoins = new System.Windows.Forms.TextBox();
            this.txtUserRole = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.timGetConsole = new System.Windows.Forms.Timer(this.components);
            this.timLoad = new System.Windows.Forms.Timer(this.components);
            this.lblRestartCount = new System.Windows.Forms.Label();
            this.lblBeeMovie = new System.Windows.Forms.Label();
            this.txtBeeMovie = new System.Windows.Forms.TextBox();
            this.btnBeeMovieSwitch = new System.Windows.Forms.Button();
            this.txtBMTime = new System.Windows.Forms.TextBox();
            this.timBM = new System.Windows.Forms.Timer(this.components);
            this.timDisconnectCheck = new System.Windows.Forms.Timer(this.components);
            this.timDCWait = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.Color.Black;
            this.txtConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.ForeColor = System.Drawing.Color.White;
            this.txtConsole.Location = new System.Drawing.Point(13, 13);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(553, 380);
            this.txtConsole.TabIndex = 0;
            // 
            // txtSubmit
            // 
            this.txtSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubmit.Location = new System.Drawing.Point(13, 400);
            this.txtSubmit.Name = "txtSubmit";
            this.txtSubmit.Size = new System.Drawing.Size(472, 26);
            this.txtSubmit.TabIndex = 1;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(491, 399);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 27);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(10, 512);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 27);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cbxServers
            // 
            this.cbxServers.FormattingEnabled = true;
            this.cbxServers.Location = new System.Drawing.Point(198, 432);
            this.cbxServers.Name = "cbxServers";
            this.cbxServers.Size = new System.Drawing.Size(121, 21);
            this.cbxServers.TabIndex = 4;
            this.cbxServers.SelectedValueChanged += new System.EventHandler(this.cbxServers_SelectedValueChanged);
            // 
            // cbxChannels
            // 
            this.cbxChannels.FormattingEnabled = true;
            this.cbxChannels.Location = new System.Drawing.Point(198, 459);
            this.cbxChannels.Name = "cbxChannels";
            this.cbxChannels.Size = new System.Drawing.Size(121, 21);
            this.cbxChannels.TabIndex = 5;
            this.cbxChannels.SelectedIndexChanged += new System.EventHandler(this.cbxChannels_SelectedIndexChanged);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(151, 435);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(41, 13);
            this.lblServer.TabIndex = 6;
            this.lblServer.Text = "Server:";
            // 
            // lblChannel
            // 
            this.lblChannel.AutoSize = true;
            this.lblChannel.Location = new System.Drawing.Point(144, 462);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(49, 13);
            this.lblChannel.TabIndex = 7;
            this.lblChannel.Text = "Channel:";
            // 
            // lblSetGame
            // 
            this.lblSetGame.AutoSize = true;
            this.lblSetGame.Location = new System.Drawing.Point(620, 21);
            this.lblSetGame.Name = "lblSetGame";
            this.lblSetGame.Size = new System.Drawing.Size(55, 13);
            this.lblSetGame.TabIndex = 8;
            this.lblSetGame.Text = "Set game:";
            // 
            // txtSetGame
            // 
            this.txtSetGame.Location = new System.Drawing.Point(684, 18);
            this.txtSetGame.Name = "txtSetGame";
            this.txtSetGame.Size = new System.Drawing.Size(100, 20);
            this.txtSetGame.TabIndex = 9;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(796, 16);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 23);
            this.btnChange.TabIndex = 10;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Black;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(470, 16);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Location = new System.Drawing.Point(333, 435);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(37, 13);
            this.lblUsers.TabIndex = 12;
            this.lblUsers.Text = "Users:";
            // 
            // cbxUsers
            // 
            this.cbxUsers.FormattingEnabled = true;
            this.cbxUsers.Location = new System.Drawing.Point(376, 432);
            this.cbxUsers.Name = "cbxUsers";
            this.cbxUsers.Size = new System.Drawing.Size(190, 21);
            this.cbxUsers.TabIndex = 13;
            this.cbxUsers.SelectedIndexChanged += new System.EventHandler(this.cbxUsers_SelectedIndexChanged);
            // 
            // lblCoins
            // 
            this.lblCoins.AutoSize = true;
            this.lblCoins.Location = new System.Drawing.Point(334, 462);
            this.lblCoins.Name = "lblCoins";
            this.lblCoins.Size = new System.Drawing.Size(36, 13);
            this.lblCoins.TabIndex = 14;
            this.lblCoins.Text = "Coins:";
            // 
            // txtCoins
            // 
            this.txtCoins.Location = new System.Drawing.Point(376, 459);
            this.txtCoins.Name = "txtCoins";
            this.txtCoins.ReadOnly = true;
            this.txtCoins.Size = new System.Drawing.Size(190, 20);
            this.txtCoins.TabIndex = 15;
            // 
            // txtUserRole
            // 
            this.txtUserRole.Location = new System.Drawing.Point(376, 485);
            this.txtUserRole.Multiline = true;
            this.txtUserRole.Name = "txtUserRole";
            this.txtUserRole.ReadOnly = true;
            this.txtUserRole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUserRole.Size = new System.Drawing.Size(190, 67);
            this.txtUserRole.TabIndex = 17;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(333, 488);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(37, 13);
            this.lblRole.TabIndex = 16;
            this.lblRole.Text = "Roles:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(91, 512);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 27);
            this.btnConnect.TabIndex = 18;
            this.btnConnect.Text = "Disconnect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // timGetConsole
            // 
            this.timGetConsole.Enabled = true;
            this.timGetConsole.Interval = 1;
            this.timGetConsole.Tick += new System.EventHandler(this.timGetConsole_Tick);
            // 
            // timLoad
            // 
            this.timLoad.Enabled = true;
            this.timLoad.Interval = 2000;
            this.timLoad.Tick += new System.EventHandler(this.timLoad_Tick);
            // 
            // lblRestartCount
            // 
            this.lblRestartCount.AutoSize = true;
            this.lblRestartCount.Location = new System.Drawing.Point(10, 542);
            this.lblRestartCount.Name = "lblRestartCount";
            this.lblRestartCount.Size = new System.Drawing.Size(75, 13);
            this.lblRestartCount.TabIndex = 19;
            this.lblRestartCount.Text = "Restart Count:";
            this.lblRestartCount.Visible = false;
            // 
            // lblBeeMovie
            // 
            this.lblBeeMovie.AutoSize = true;
            this.lblBeeMovie.Location = new System.Drawing.Point(614, 59);
            this.lblBeeMovie.Name = "lblBeeMovie";
            this.lblBeeMovie.Size = new System.Drawing.Size(61, 13);
            this.lblBeeMovie.TabIndex = 20;
            this.lblBeeMovie.Text = "Bee Movie:";
            // 
            // txtBeeMovie
            // 
            this.txtBeeMovie.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtBeeMovie.ForeColor = System.Drawing.Color.Red;
            this.txtBeeMovie.Location = new System.Drawing.Point(684, 56);
            this.txtBeeMovie.Name = "txtBeeMovie";
            this.txtBeeMovie.ReadOnly = true;
            this.txtBeeMovie.Size = new System.Drawing.Size(100, 20);
            this.txtBeeMovie.TabIndex = 21;
            this.txtBeeMovie.Text = "DISABLED";
            this.txtBeeMovie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnBeeMovieSwitch
            // 
            this.btnBeeMovieSwitch.Location = new System.Drawing.Point(796, 54);
            this.btnBeeMovieSwitch.Name = "btnBeeMovieSwitch";
            this.btnBeeMovieSwitch.Size = new System.Drawing.Size(75, 23);
            this.btnBeeMovieSwitch.TabIndex = 22;
            this.btnBeeMovieSwitch.Text = "Enable";
            this.btnBeeMovieSwitch.UseVisualStyleBackColor = true;
            this.btnBeeMovieSwitch.Click += new System.EventHandler(this.btnBeeMovieSwitch_Click);
            // 
            // txtBMTime
            // 
            this.txtBMTime.Location = new System.Drawing.Point(684, 82);
            this.txtBMTime.Name = "txtBMTime";
            this.txtBMTime.ReadOnly = true;
            this.txtBMTime.Size = new System.Drawing.Size(100, 20);
            this.txtBMTime.TabIndex = 23;
            this.txtBMTime.Text = "Time";
            this.txtBMTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBMTime.Visible = false;
            // 
            // timBM
            // 
            this.timBM.Interval = 500;
            this.timBM.Tick += new System.EventHandler(this.timBM_Tick);
            // 
            // timDisconnectCheck
            // 
            this.timDisconnectCheck.Enabled = true;
            this.timDisconnectCheck.Interval = 5000;
            this.timDisconnectCheck.Tick += new System.EventHandler(this.timDisconnectCheck_Tick);
            // 
            // timDCWait
            // 
            this.timDCWait.Interval = 2000;
            this.timDCWait.Tick += new System.EventHandler(this.timDCWait_Tick);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(172, 512);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 27);
            this.btnExit.TabIndex = 24;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // mainForm
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 564);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtBMTime);
            this.Controls.Add(this.btnBeeMovieSwitch);
            this.Controls.Add(this.txtBeeMovie);
            this.Controls.Add(this.lblBeeMovie);
            this.Controls.Add(this.lblRestartCount);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtUserRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtCoins);
            this.Controls.Add(this.lblCoins);
            this.Controls.Add(this.cbxUsers);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.txtSetGame);
            this.Controls.Add(this.lblSetGame);
            this.Controls.Add(this.lblChannel);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.cbxChannels);
            this.Controls.Add(this.cbxServers);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtSubmit);
            this.Controls.Add(this.txtConsole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "mainForm";
            this.Text = "LennyBot Controller";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSubmit;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cbxServers;
        private System.Windows.Forms.ComboBox cbxChannels;
        public System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.Label lblSetGame;
        private System.Windows.Forms.TextBox txtSetGame;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.ComboBox cbxUsers;
        private System.Windows.Forms.Label lblCoins;
        private System.Windows.Forms.TextBox txtCoins;
        private System.Windows.Forms.TextBox txtUserRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Timer timGetConsole;
        private System.Windows.Forms.Timer timLoad;
        private System.Windows.Forms.Label lblRestartCount;
        private System.Windows.Forms.Label lblBeeMovie;
        private System.Windows.Forms.TextBox txtBeeMovie;
        private System.Windows.Forms.Button btnBeeMovieSwitch;
        private System.Windows.Forms.TextBox txtBMTime;
        private System.Windows.Forms.Timer timBM;
        private System.Windows.Forms.Timer timDisconnectCheck;
        private System.Windows.Forms.Timer timDCWait;
        private System.Windows.Forms.Button btnExit;
    }
}