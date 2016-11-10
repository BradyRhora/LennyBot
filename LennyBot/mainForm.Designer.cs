﻿namespace LennyBot
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
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.txtSubmit = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
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
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(13, 525);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 27);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cbxServers
            // 
            this.cbxServers.FormattingEnabled = true;
            this.cbxServers.Location = new System.Drawing.Point(445, 432);
            this.cbxServers.Name = "cbxServers";
            this.cbxServers.Size = new System.Drawing.Size(121, 21);
            this.cbxServers.TabIndex = 4;
            this.cbxServers.SelectedValueChanged += new System.EventHandler(this.cbxServers_SelectedValueChanged);
            // 
            // cbxChannels
            // 
            this.cbxChannels.FormattingEnabled = true;
            this.cbxChannels.Location = new System.Drawing.Point(445, 459);
            this.cbxChannels.Name = "cbxChannels";
            this.cbxChannels.Size = new System.Drawing.Size(121, 21);
            this.cbxChannels.TabIndex = 5;
            this.cbxChannels.SelectedIndexChanged += new System.EventHandler(this.cbxChannels_SelectedIndexChanged);
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(398, 435);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(41, 13);
            this.lblServer.TabIndex = 6;
            this.lblServer.Text = "Server:";
            // 
            // lblChannel
            // 
            this.lblChannel.AutoSize = true;
            this.lblChannel.Location = new System.Drawing.Point(391, 462);
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
            this.lblUsers.Location = new System.Drawing.Point(580, 435);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(37, 13);
            this.lblUsers.TabIndex = 12;
            this.lblUsers.Text = "Users:";
            // 
            // cbxUsers
            // 
            this.cbxUsers.FormattingEnabled = true;
            this.cbxUsers.Location = new System.Drawing.Point(623, 432);
            this.cbxUsers.Name = "cbxUsers";
            this.cbxUsers.Size = new System.Drawing.Size(121, 21);
            this.cbxUsers.TabIndex = 13;
            // 
            // lblCoins
            // 
            this.lblCoins.AutoSize = true;
            this.lblCoins.Location = new System.Drawing.Point(587, 462);
            this.lblCoins.Name = "lblCoins";
            this.lblCoins.Size = new System.Drawing.Size(36, 13);
            this.lblCoins.TabIndex = 14;
            this.lblCoins.Text = "Coins:";
            // 
            // txtCoins
            // 
            this.txtCoins.Location = new System.Drawing.Point(623, 459);
            this.txtCoins.Name = "txtCoins";
            this.txtCoins.ReadOnly = true;
            this.txtCoins.Size = new System.Drawing.Size(75, 20);
            this.txtCoins.TabIndex = 15;
            // 
            // txtUserRole
            // 
            this.txtUserRole.Location = new System.Drawing.Point(623, 485);
            this.txtUserRole.Multiline = true;
            this.txtUserRole.Name = "txtUserRole";
            this.txtUserRole.ReadOnly = true;
            this.txtUserRole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUserRole.Size = new System.Drawing.Size(89, 20);
            this.txtUserRole.TabIndex = 17;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(580, 488);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(37, 13);
            this.lblRole.TabIndex = 16;
            this.lblRole.Text = "Roles:";
            // 
            // mainForm
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 564);
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
            this.Controls.Add(this.btnLoad);
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
        private System.Windows.Forms.Button btnLoad;
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
    }
}