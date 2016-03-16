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
using Blackjack.GameReference;
using System.ServiceModel;
using System.Threading;
using System.Windows.Threading;

namespace Blackjack
{

    public partial class StartForm : IGameCallback
    {
        public PlayerData Player
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
        private PlayerData _player;
        private GameReference.Table _currentTable;
        private List<GameReference.Table> _serverTableList;
        private GameReference.GameClient _server;

        private GameWindow gameWindow;

        public StartForm()
        {
            InitializeComponent();
            this.Loaded += StartForm_Loaded;
        }

        private void StartForm_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateTableList();
        }

        public StartForm(PlayerData player, GameReference.GameClient server)
        {
            _server = server;
            this._player = player;
            InitializeComponent();
            PopulateTableList();
        }

        private async void PopulateTableList(bool updateFromServer = true)
        {

            if (updateFromServer)
            {
                var serverTableList = await _server.ListTablesAsync();
                if (serverTableList == null)
                    return;
               _serverTableList = serverTableList.ToList();
            }

           
            
            
            tablesList.Items.Clear();
            int i = 0;
            foreach (var tb in _serverTableList)
            {
                var numOfPlayers = tb.Players == null ? 0 : tb.Players.Count;
                var labelString = "Table #" + i++ + " | " + numOfPlayers + " / 6 | ";
                var lb = new Label()
                {
                    Content = labelString
                };
                var li = new ListBoxItem();
                li.Content = lb;

                tablesList.Items.Add(li);
            }

            
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

        private async void joinTableButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var i = tablesList.SelectedIndex;

            _currentTable = await _server.JoinTableAsync(i);

            if (_currentTable == null)
            {
                MessageBox.Show("Table in game or closed");
                return;
            }

            gameWindow = new GameWindow(_player, _currentTable, _server);
            gameWindow.ShowDialog();
            this.Show();
        }

        private void createTableButton_Click(object sender, RoutedEventArgs e)
        {

            _server.CreateTableAsync();

        }

        public void OnBet(object sender, GameArgs e)
        {
            //throw new NotImplementedException();

            // update table bets
            gameWindow?.OnBet(sender, e);
        }

        public void OnDeal(object sender, GameArgs e)
        {
            //throw new NotImplementedException();
            // game starts

            gameWindow?.SetUpGameInPlay();
        }

        public void OnFold(object sender, GameArgs e)
        {
            gameWindow?.OnFold(sender, e);
        }

        public void OnHit(object sender, GameArgs e)
        {
            gameWindow?.OnHit(sender, e);
        }

        public void OnJoin(object sender, GameArgs e)
        {
            //throw new NotImplementedException();
            // update table ui
            gameWindow?.OnJoin(sender, e);
            
        }

        public void OnLeave(object sender, GameArgs e)
        {
            gameWindow?.OnLeave(sender, e);
        }

        public void OnNewTableCreated(object sender, List<GameReference.Table> tableList)
        {
            _serverTableList = tableList;
            PopulateTableList(false);
            
        }

        public void OnMyTurn(object sender, GameArgs e)
        {
            gameWindow?.OnMyTurn(sender, e);
        }

        public void OnStand(object sender, GameArgs e)
        {
            gameWindow?.OnStand(sender, e);
        }
    }
}
