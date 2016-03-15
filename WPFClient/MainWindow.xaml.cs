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
using System.ServiceModel;
using System.Threading;
using System.Windows.Threading;
using Blackjack.Service;

namespace Blackjack
{

    public partial class StartForm : Service.IGameServiceCallback
    {
        public Player Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
            }
        }
        private Player _player;
        private List<Service.Table> _serverTableList;

        public StartForm()
        {
            InitializeComponent();
            Loaded += StartForm_Loaded;
        }

        private void StartForm_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateTableList();
        }

        public StartForm(Player player)
        {
            _player = player;
            InitializeComponent();
            PopulateTableList();
        }

        private void PopulateTableList()
        {
            Dispatcher.Invoke(async () =>
            {
                var serverTableList = await LoginWindow.GameServer.ListTablesAsync();
                tablesList.Items.Clear();
                int i = 0;
                foreach (var tb in serverTableList)
                {

                    var numOfPlayers = tb.Players == null ? 0 : tb.Players.Length;
                    var labelString = "Table #" + i++ + " | " + numOfPlayers + " / 6 | ";
                    var lb = new Label()
                    {
                        Content = labelString
                    };
                    var li = new ListBoxItem();
                    li.Content = lb;

                    tablesList.Items.Add(li);
                }

                tablesList.UpdateLayout();
            });
        }



        //private void NewGame(object sender, RoutedEventArgs e)
        //{
        //    this.Hide();
        //    GameWindow gameWindow = new GameWindow(player);
        //    gameWindow.ShowDialog();
        //    this.Show();
        //}

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

        private void joinTableButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var i = tablesList.SelectedIndex;

            GameWindow gameWindow = new GameWindow(_player, _serverTableList[i] as Service.Table);
            gameWindow.ShowDialog();
            this.Show();
        }

        private void createTableButton_Click(object sender, RoutedEventArgs e)
        {

            LoginWindow.GameServer.CreateTableAsync();

        }

        public void OnBet(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnDeal(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnFold(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnHit(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnJoin(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnLeave(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnNewTableCreated(object sender, GameArgs e)
        {
            PopulateTableList();
        }

        public void OnNextTurn(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
