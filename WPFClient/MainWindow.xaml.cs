using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Blackjack
{
    public partial class StartForm : Window
    {
        public StartForm()
        {
            InitializeComponent();
        }
        
        private void NewGame(object sender, RoutedEventArgs e)
        {
            this.Hide();

            using (var gc = new GameReference.GameClient())
            {
                var g = gc.CreateTable();
                var p = gc.Login("kosta1", "123");
                var ss = new Blackjack.GameReference.Table();
            
            }
            GameWindow gameWindow = new GameWindow();
            gameWindow.ShowDialog();
            this.Show();
        }

        private void Options(object sender, RoutedEventArgs e)
        {
            this.Hide();
            OptionsWindow optionsWindow = new OptionsWindow();
            optionsWindow.ShowDialog();
            this.Show();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
