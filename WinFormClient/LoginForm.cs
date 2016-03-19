using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class LoginForm : Form
    {
        private string WINDOW_TITLE = ".Net Final BlackJack Multiplayer";
        private GameReference.GameClient _server;
        private StartForm _startForm;

        public LoginForm()
        {
            InitializeComponent();
            this.Text = WINDOW_TITLE;

            _startForm = new StartForm(_server);
            var contax = new System.ServiceModel.InstanceContext(_startForm);
            _server = new GameReference.GameClient(contax);

        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            this.Text = WINDOW_TITLE + " : Connecting... please wait...";
            lBwrongPass.Visible = false;

            var player = await _server.LoginAsync(tBuserName.Text, tBpassword.Text);
            this.Text = WINDOW_TITLE;
            _startForm.Player = player;
            if (player != null)
            {
                _startForm.Visible = true;
                this.Hide();
            }
            else
            {
                lBwrongPass.Visible = true;
            }
        }
    }
}
