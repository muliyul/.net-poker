using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Blackjack
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static GameReference.GameClient Server;
        public static InstanceContext InstContext;
        private StartForm startForm;
        public LoginWindow()
        {
            InitializeComponent();
            startForm = new StartForm();
            InstContext = new InstanceContext(startForm);
            var bindings = ConfigurationManager.GetSection("system.serviceModel/bindings") as
                        System.ServiceModel.Configuration.BindingsSection;
            Server = new GameReference.GameClient(InstContext, bindings.NetTcpBinding.Bindings[0].Name);
            startForm.Server = Server;
        }

        private async void BtLogin_Click(object sender, RoutedEventArgs e)
        {
            Spinner.Visibility = Visibility.Visible;
            var player = await Server.LoginAsync(TbUserName.Text, PbPassword.Password);
            Spinner.Visibility = Visibility.Hidden;
            startForm.Player = player;
            if (player != null)
            {
                startForm.Visibility = Visibility.Visible;
                Hide();
            }
            else
            {
                LbWrongPass.Visibility = Visibility.Visible;
            }
            
        }


    }
}
