using System;
using System.Windows.Forms;
using BlackJack.GameReference;

namespace BlackJack
{
    partial class StartForm : Form , GameReference.IGameCallback
    {
        private GameClient _server;

        public PlayerData Player { get; internal set; }

        /// <summary>
        /// Main constructor for StartForm
        /// </summary>
        public StartForm(GameReference.GameClient server)
        {
            InitializeComponent();
            _server = server;
		}
		
        /// <summary>
        /// Invokes a new BlackJack game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void NewGameBtn_Click(object sender, EventArgs e)
        {
            // Show the main BlackJack UI game
			using (BlackJackForm blackjackform = new BlackJackForm())
			{
				Hide();
				blackjackform.ShowDialog();
				Show();
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
            throw new NotImplementedException();
        }

        public void OnLeave(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnHit(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnBet(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnStatus(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnDeal(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnNewTableCreated(object sender, Table[] tableList)
        {
            throw new NotImplementedException();
        }

        public void OnMyTurn(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnStand(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnDealerPlay(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }

        public void OnResetTable(object sender, GameArgs e)
        {
            throw new NotImplementedException();
        }
    }
}