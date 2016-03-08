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
using System.Windows.Shapes;

namespace Blackjack
{
    public partial class OptionsWindow : Window
    {
        public OptionsWindow()
        {
            InitializeComponent();
        }

        private void ImageListViewChanged(object sender, SelectionChangedEventArgs e)
        {
            Image imageListBox = (Image)((ListBoxItem)ImageList.SelectedItem).Content;
            prevImage.Source = imageListBox.Source;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Ok(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.PlayerName = playerNameTextBox.Text;
            if (prevImage.Source != null) 
                Properties.Settings.Default.PlayerImage = prevImage.Source.ToString();
            Properties.Settings.Default.Save();
            this.Close();
        }
    }
}
