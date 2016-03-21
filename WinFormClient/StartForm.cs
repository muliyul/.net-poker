using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BlackJack.GameReference;

namespace BlackJack
{
    partial class StartForm : Form , GameReference.IGameCallback
    {
        public GameClient Server;
        private BlackJackForm _blackJackForm;
        private List<Table> _serverTableList;
        private Table _currentTable;
        
        public PlayerData Player { get; internal set; }

        /// <summary>
        /// Main constructor for StartForm
        /// </summary>
        public StartForm()
        {
            InitializeComponent();
          
            Shown += StartForm_Shown;  
          
        }

        private void StartForm_Shown(object sender, EventArgs e)
        {
            this.Text += " - Welcome " + Player.Username;
            PopulateTableList();
        }


        /// <summary>
        /// Invokes a new BlackJack game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NewGameBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var i = tablesListBox.SelectedIndex;

            if (i < 0)
            {
                MessageBox.Show("Select a room first");
                this.Show();
            }
            else
            {
                _currentTable = await Server.JoinTableAsync(i);

                if (_currentTable == null)
                {
                    MessageBox.Show("Table in game or closed");
                    this.Show();
                }
                else
                {
                    _blackJackForm = new BlackJackForm(Player, _currentTable, Server);
                    _blackJackForm.ShowDialog();
                    this.Show();
                }
            }
        }

        /// <summary>
        /// Brings up the options form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void OptionsBtn_Click(object sender, EventArgs e)
        {
            // Show the Options panel
			using (OptionsForm optionsForm = new OptionsForm())
			{
				Hide();
				optionsForm.ShowDialog();
				Show();
			}
		}

        /// <summary>
        /// Exits the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void ExitBtn_Click(object sender, EventArgs e)
        {
            // Exit the Game
            Application.Exit();
		}

        public void OnJoin(object sender, GameArgs e)
        {
            _blackJackForm?.OnJoin(sender, e);
        }

        public void OnLeave(object sender, GameArgs e)
        {
            _blackJackForm?.OnLeave(sender, e);
        }

        public void OnHit(object sender, GameArgs e)
        {
            _blackJackForm?.OnHit(sender, e);
        }

        public void OnBet(object sender, GameArgs e)
        {
            _blackJackForm?.OnBet(sender, e);
        }

     

        public void OnDeal(object sender, GameArgs e)
        {
            _blackJackForm?.OnDeal(sender, e);
        }

        public void OnNewTableCreated(object sender, List<Table> tableList)
        {
            
        }

        public void OnMyTurn(object sender, GameArgs e)
        {
            _blackJackForm?.OnMyTurn(sender, e);
        }

        public void OnStand(object sender, GameArgs e)
        {
            _blackJackForm?.OnStand(sender, e);
        }

        public void OnDealerPlay(object sender, GameArgs e)
        {
            _blackJackForm?.OnDealerPlay(sender, e);
        }

        public void OnResetTable(object sender, GameArgs e)
        {
            _blackJackForm.OnResetTable(sender, e); 
        }

        public void OnRoundResult(object sender, GameArgs e)
        {
            _blackJackForm.OnRoundResult(sender, e);
        }

        public void OnTableListUpdate(object sender, List<Table> tableList)
        {

            _serverTableList = tableList;
            PopulateTableList(false);
        }

        private async void PopulateTableList(bool updateFromServer = true)
        {
            if (updateFromServer)
                _serverTableList = await Server.ListTablesAsync();


            tablesListBox.Items.Clear();
            int i = 0;
            foreach (var tb in _serverTableList)
            {
                var numOfPlayers = tb.Players == null ? 0 : tb.Players.Count;
                var isOpen = tb.InGame ? " Closed " : "Waiting for players";
                var labelString = "Table #" + i++ + " | " + numOfPlayers + " / 6 | " + isOpen;


                tablesListBox.Items.Add(labelString);
            }
        }

        private void createTableButton_Click(object sender, EventArgs e)
        {
            Server.CreateTable();
        }
    }
}