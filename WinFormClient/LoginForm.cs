using System;
using System.Collections.Generic;
using System.Configuration;
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
            tBpassword.KeyPress += TBpassword_KeyPress;
            this.Text = WINDOW_TITLE;

            var bindings = ConfigurationManager.GetSection("system.serviceModel/bindings") as
                       System.ServiceModel.Configuration.BindingsSection;
         
            _startForm = new StartForm();
            var instContext = new System.ServiceModel.InstanceContext(_startForm);
            _server = new GameReference.GameClient(instContext, bindings.NetTcpBinding.Bindings[0].Name);
            _startForm.Server = _server;

        }

        private void TBpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Keys.Enter))
                submitButton_Click(sender, e);
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
