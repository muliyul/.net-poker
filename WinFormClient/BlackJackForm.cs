using System;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using BlackJack.GameReference;
using System.Linq;

namespace BlackJack
{
    partial class BlackJackForm : Form, GameReference.IGameCallback
    {
        #region Fields

        //Creates a new blackjack game with one player and an inital balance set through the settings designer

        private PictureBox[] playerCards;
        private PictureBox[] dealerCards;

        private List<Label> _playerNameLabels = new List<Label>();
        private List<Label> _playerLabelsTotalCardVal = new List<Label>();
        private List<TextBox> _playerBetAmountLabels = new List<TextBox>();
        private List<TextBox> _playerWinStatusLabels = new List<TextBox>();
        private Table _table;


        private GameClient _server;
        private decimal _currentBet;
        private PlayerData _me;
        private bool _firstTurn;
        private int _ties = 0;

        #endregion

        #region Main Constructor

        /// <summary>
        /// Main constructor for the BlackJackForm.  Initializes components, loads the card skin images, and sets up the new game
        /// </summary>
        public BlackJackForm(PlayerData player, Table _currentTable, GameClient _server)
        {
            InitializeComponent();
            this._me = player;
            this._table = _currentTable;
            this._server = _server;
            Text += " :: Logged in as " + player.Username;
            FormClosed += BlackJackForm_FormClosed;

            _playerNameLabels.Add(playerNameLabel1);
            _playerNameLabels.Add(playerNameLabel2);
            _playerNameLabels.Add(playerNameLabel3);
            _playerNameLabels.Add(playerNameLabel4);
            _playerNameLabels.Add(playerNameLabel5);

            _playerLabelsTotalCardVal.Add(playerTotalLabel1);
            _playerLabelsTotalCardVal.Add(playerTotalLabel2);
            _playerLabelsTotalCardVal.Add(playerTotalLabel3);
            _playerLabelsTotalCardVal.Add(playerTotalLabel4);
            _playerLabelsTotalCardVal.Add(playerTotalLabel5);

            _playerBetAmountLabels.Add(myBetTextBox1);
            _playerBetAmountLabels.Add(myBetTextBox2);
            _playerBetAmountLabels.Add(myBetTextBox3);
            _playerBetAmountLabels.Add(myBetTextBox4);
            _playerBetAmountLabels.Add(myBetTextBox5);

            _playerWinStatusLabels.Add(playerWinStatusLabel1);
            _playerWinStatusLabels.Add(playerWinStatusLabel2);
            _playerWinStatusLabels.Add(playerWinStatusLabel3);
            _playerWinStatusLabels.Add(playerWinStatusLabel4);
            _playerWinStatusLabels.Add(playerWinStatusLabel5);



            LoadCardSkinImages();
            ClearTableCards();
            SetUpNewGame();
        }

        private void BlackJackForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _server.Leave();
            _me.Bet = 0;
            _me.WonHands = 0;
            _me.LostHands = 0;

        }

        private void ClearTableCards()
        {
            ClearTable();

            _playerWinStatusLabels.ForEach(p => p.Text = null);
            _playerWinStatusLabels.ForEach(p => p.Visible = false);
            _playerNameLabels.ForEach(pl => pl.ForeColor = Color.White);

            WinStatusDealer.Text = null;
            WinStatusDealer.Visible = false;
            WinStatus.Text = null;
            WinStatus.Visible = false;
        }



        #endregion

        #region Game Event Handlers

        /// <summary>
        /// Invoked when the deal button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DealBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // If the current bet is equal to 0, ask the player to place a bet
                if ((_currentBet == 0) && (_me.Bank > 0))
                {
                    MessageBox.Show("You must place a bet before the dealer deals.", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    // Place the bet
                    _server.Bet(_currentBet, false);

                    _server.Deal();

                    dealButton.Enabled = clearBetButton.Enabled = false;
                    // shoud be call back to it ShowBankValue();

                }
            }
            catch (Exception NotEnoughMoneyException)
            {
                MessageBox.Show(NotEnoughMoneyException.Message);
            }
        }

        /// <summary>
        /// Invoked when the player has finished their turn and clicked the stand button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StandBtn_Click(object sender, EventArgs e)
        {
            // Dealer should finish playing and the UI should be updated
            _server.Stand();
            hitButton.Enabled = standButton.Enabled = false;
        }

        /// <summary>
        /// Invoked when the hit button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HitBtn_Click(object sender, EventArgs e)
        {
            _firstTurn = false;
            endGameButton.Enabled = false;

            _server.Hit();
            hitButton.Enabled = false;
        }

        /// <summary>
        /// Invoked when the double down button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DblDwnBtn_Click(object sender, EventArgs e)
        {
            _server.Bet(_currentBet, true);
        }

        /// <summary>
        /// Exits the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Place a bet for 10 dollars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TenBtn_Click(object sender, EventArgs e)
        {
            Bet(10);
        }

        /// <summary>
        /// Place a bet for 25 dollars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwentyFiveBtn_Click(object sender, EventArgs e)
        {
            Bet(25);
        }

        /// <summary>
        /// Place a bet for 50 dollars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FiftyBtn_Click(object sender, EventArgs e)
        {
            Bet(50);
        }

        /// <summary>
        /// Place a bet for 100 dollars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HundredBtn_Click(object sender, EventArgs e)
        {
            Bet(100);
        }

        /// <summary>
        /// Clear the bet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearBetBtn_Click(object sender, EventArgs e)
        {
            //Clear the bet amount
            _currentBet = 0m;
            ShowBankValue();
        }

        #endregion

        #region Game Methods

        /// <summary>
        /// This method updates the current bet by a specified bet amount
        /// </summary>
        /// <param name="betValue"></param>
        private void Bet(decimal betValue)
        {
            try
            {
                // Update the bet amount
                _currentBet += betValue;
                // Update the "My Bet" and "My Account" values
                ShowBankValue();
            }
            catch (Exception NotEnoughMoneyException)
            {
                MessageBox.Show(NotEnoughMoneyException.Message);
            }
        }

        /// <summary>
        /// Set the "My Account" value in the UI
        /// </summary>
        private void ShowBankValue()
        {
            // Update the "My Account" value
            myAccountTextBox.Text = "$" + (_me.Bank - _currentBet);

            var player = _table.Players.SingleOrDefault(p => p.Username.Equals(_me.Username));
            var playerIndex = _table.Players.IndexOf(player);

            _playerBetAmountLabels[playerIndex].Text = _currentBet.ToString() + "$";


        }

        /// <summary>
        /// Clear the dealer and player cards
        /// </summary>
        private void ClearTable()
        {
            for (int i = 0; i < 6; i++)
            {
                dealerCards[i].Image = null;
                dealerCards[i].Visible = false;
            }

            foreach (var p in playerCards)
            {
                p.Image = null;
                p.Visible = false;
            }
        }


        #endregion

        #region Game UI Methods

        /// <summary>
        /// Load the Deck Card Images
        /// </summary>
        private void LoadCardSkinImages()
        {
            try
            {
                // Load the card skin image from file
                Image cardSkin = Image.FromFile(Properties.Settings.Default.CardGameImageSkinPath);
                // Set the three cards on the UI to the card skin image
                deckCard1PictureBox.Image = cardSkin;
                deckCard2PictureBox.Image = cardSkin;
                deckCard3PictureBox.Image = cardSkin;
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Card skin images are not loading correctly.  Make sure the card skin images are in the correct location.");
            }

            playerCards = new PictureBox[] {
                player1Card1,
                player1Card2,
                player1Card3,
                player1Card4,
                player1Card5,
                player1Card6,

                player2Card1,
                player2Card2,
                player2Card3,
                player2Card4,
                player2Card5,
                player2Card6,

                player3Card1,
                player3Card2,
                player3Card3,
                player3Card4,
                player3Card5,
                player3Card6,

                player4Card1,
                player4Card2,
                player4Card3,
                player4Card4,
                player4Card5,
                player4Card6,

                player5Card1,
                player5Card2,
                player5Card3,
                player5Card4,
                player5Card5,
                player5Card6
            };

            dealerCards = new PictureBox[] {
                dealerCard1PictureBox,
                dealerCard2PictureBox,
                dealerCard3PictureBox,
                dealerCard4PictureBox,
                dealerCard5PictureBox,
                dealerCard6PictureBox
            };
        }

        /// <summary>
        /// Set up the UI for when the game is in play after the player has hit deal game
        /// </summary>
        private void SetUpGameInPlay()
        {
            tenButton.Enabled = false;
            twentyFiveButton.Enabled = false;
            fiftyButton.Enabled = false;
            hundredButton.Enabled = false;
            clearBetButton.Enabled = false;
            standButton.Enabled = false;
            hitButton.Enabled = false;

            dealButton.Enabled = false;

            for (int i = 0; i < _table.Players.Count; ++i)
            {
                _playerLabelsTotalCardVal[i].Visible = true;
            }

            if (_firstTurn)
                doubleDownButton.Enabled = false;
        }

        /// <summary>
        /// Set up the UI for a new game
        /// </summary>
        private void SetUpNewGame()
        {


            UpdatePlayers();
            UpdatePlayersBet();

            hitButton.Enabled = false;

            dealButton.Enabled = true;
            doubleDownButton.Enabled = false;
            standButton.Enabled = false;
            hitButton.Enabled = false;
            clearBetButton.Enabled = true;
            tenButton.Enabled = true;
            twentyFiveButton.Enabled = true;
            fiftyButton.Enabled = true;
            hundredButton.Enabled = true;
            endGameButton.Enabled = true;

            _playerLabelsTotalCardVal.ForEach(p => p.Visible = false);
            _playerBetAmountLabels.ForEach(l => l.Text = "0");

            _firstTurn = true;
            ShowBankValue();
        }

        private void UpdatePlayersBet()
        {
            foreach (var playerIdx in _table.Players.FindAll(p => !p.Username.Equals(_me.Username)).Select(p => _table.Players.IndexOf(p)))
            {
                _playerBetAmountLabels[playerIdx].Text = _table.Players[playerIdx].Bet.ToString() + "$";
            }
        }

        /// <summary>
        /// Refresh the UI to update the player cards
        /// </summary>
        private void UpdateUIPlayerCards()
        {
            // Update the value of the hand
            for (int i = 0; i < _table.Players.Count; i++)
            {
                _playerLabelsTotalCardVal[i].Text = HandValue(_table.Players[i].Hand).ToString();
                List<GameReference.Card> pCards = _table.Players[i].Hand.Cards;
                for (int j = 0; j < pCards.Count; j++)
                {
                    // Load each card from file
                    LoadCard(playerCards[j + (i * 6)], pCards[j]);
                    playerCards[j + (i * 6)].Visible = true;
                    playerCards[j + (i * 6)].BringToFront();
                }
            }
            List<Card> dcards = _table.Dealer.Hand.Cards;
            WinStatusDealer.Text = HandValue(_table.Dealer.Hand).ToString();

            for (int i = 0; i < dcards.Count; i++)
            {
                LoadCard(dealerCards[i], dcards[i]);
                dealerCards[i].Visible = true;
                dealerCards[i].BringToFront();
            }
        }
        private int HandValue(GameReference.Hand hand)
        {
            int sum = hand.Cards.Sum(card => card.Value);
            int aces = hand.Cards.Count(card => card.Face == Face.Ace);

            while (sum > 21 && aces-- > 0) sum -= 10;
            return sum;
        }
        /// <summary>
        /// Takes the card value and loads the corresponding card image from file
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="c"></param>
        private void LoadCard(PictureBox pb, Card c)
        {
            try
            {
                StringBuilder image = new StringBuilder();

                switch (c.Suit)
                {
                    case Suit.Diamonds:
                        image.Append("di");
                        break;
                    case Suit.Hearts:
                        image.Append("he");
                        break;
                    case Suit.Spades:
                        image.Append("sp");
                        break;
                    case Suit.Clubs:
                        image.Append("cl");
                        break;
                }

                switch (c.Face)
                {
                    case Face.Ace:
                        image.Append("1");
                        break;
                    case Face.Ten:
                        if (c.Face.ToString().Equals(Face.Ten.ToString()))
                            image.Append("10");
                        else if (c.Face.ToString().Equals(Face.Queen.ToString()))
                            image.Append("q");
                        else if (c.Face.ToString().Equals(Face.King.ToString()))
                            image.Append("k");
                        else if (c.Face.ToString().Equals(Face.Jack.ToString()))
                            image.Append("j");
                        break;

                    case Face.Nine:
                        image.Append("9");
                        break;
                    case Face.Eight:
                        image.Append("8");
                        break;
                    case Face.Seven:
                        image.Append("7");
                        break;
                    case Face.Six:
                        image.Append("6");
                        break;
                    case Face.Five:
                        image.Append("5");
                        break;
                    case Face.Four:
                        image.Append("4");
                        break;
                    case Face.Three:
                        image.Append("3");
                        break;
                    case Face.Two:
                        image.Append("2");
                        break;
                }

                image.Append(Properties.Settings.Default.CardGameImageExtension);
                string cardGameImagePath = Properties.Settings.Default.CardGameImagePath;
                string cardGameImageSkinPath = Properties.Settings.Default.CardGameImageSkinPath;
                image.Insert(0, cardGameImagePath);
                //check to see if the card should be faced down or up;
                if (!c.IsCardUp)
                    image.Replace(image.ToString(), cardGameImageSkinPath);

                pb.Image = new Bitmap(image.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Card images are not loading correctly.  Make sure all card images are in the right location.");
            }
        }
        private void UpdatePlayers()
        {
            _playerNameLabels.ForEach(p => p.Text = string.Empty);
            for (int i = 0; i < _table.Players.Count; ++i)
            {
                _playerNameLabels[i].Text = _table.Players[i].Username;
            }
        }
        public void OnJoin(object sender, GameArgs e)
        {
            if (e.Table != null)
            {
                _table = e.Table;
                UpdatePlayers();

            }
        }



        public void OnLeave(object sender, GameArgs e)
        {
            var player = _table.Players.SingleOrDefault(p => p.Username.Equals(e.Player.Username));
            _table.Players.Remove(player);
            UpdatePlayers();
        }

        public void OnHit(object sender, GameArgs e)
        {
            bool myAction = e.Player.Username.Equals(_me.Username);
            var player = _table.Players.Find(p => p.Username.Equals(e.Player.Username));
            var playerIndex = _table.Players.IndexOf(player);
            e.Card.IsCardUp = true;
            player.Hand.Cards.Add(e.Card);
            UpdateUIPlayerCards();

            if (myAction)
                hitButton.Enabled = true;

            if (e.Message != null)
            {
                _playerWinStatusLabels[playerIndex].Text = e.Message;
                _playerWinStatusLabels[playerIndex].Visible = true;
            }

        }

        public void OnBet(object sender, GameArgs e)
        {
            var player = _table.Players.SingleOrDefault(p => p.Username.Equals(e.Player.Username));
            player.Bet = e.Amount;
            UpdatePlayersBet();
        }


        public void OnDeal(object sender, GameArgs e)
        {
            _table = e.Table;
            ClearTableCards();
            hitButton.Enabled = doubleDownButton.Enabled = false;

            UpdatePlayersBet();
            UpdateUIPlayerCards();
            SetUpGameInPlay();
        }

        public void OnNewTableCreated(object sender, List<Table> tableList)
        {

        }

        public void OnMyTurn(object sender, GameArgs e)
        {
            _table = e.Table;

            _playerNameLabels.ForEach(pl => pl.ForeColor = Color.White);
            _playerNameLabels.FirstOrDefault(p => e.Player.Username.Equals(p.Text)).ForeColor = Color.Yellow;

            if (e.Player.Username.Equals(_me.Username))
            {
                standButton.Enabled =
                hitButton.Enabled = true;
                endGameButton.Enabled = false;
            }

            UpdateUIPlayerCards();
        }

        public void OnStand(object sender, GameArgs e)
        {

        }

        public void OnDealerPlay(object sender, GameArgs e)
        {
            WinStatusDealer.Visible = true;
            _table.Dealer.Hand = e.Player.Hand;

            WinStatus.Visible = true;
            UpdateUIPlayerCards();
        }

        public void OnResetTable(object sender, GameArgs e)
        {
            var xUser = e.Table.Players.Find(p => p.Username.Equals(_me.Username));

            _me.Bank = xUser.Bank;
            _me.Bet = xUser.Bet;
            _me.WonHands = xUser.WonHands;
            _me.Hand = xUser.Hand;

            ShowBankValue();
            ClearTableCards();
            ClearBetBtn_Click(null, null);
            SetUpNewGame();
        }

        public void OnRoundResult(object sender, GameArgs e)
        {
            var player = _table.Players.Single(p => p.Username.Equals(e.Player.Username));
            var playerIndex = _table.Players.IndexOf(player);

            if (e.Player.Username.Equals(_me.Username))
            {
                _me.Bank = e.Table.Players[playerIndex].Bank;
                _me.Bet = e.Table.Players[playerIndex].Bet;
                _me.WonHands = e.Table.Players[playerIndex].WonHands;
                _me.Hand = e.Table.Players[playerIndex].Hand;
                winTextBox.Text = e.Player.WonHands.ToString();
                lossTextBox.Text = e.Player.LostHands.ToString();
                if (e.Message.Contains("Tie"))
                    _ties++;
                tiesTextBox.Text = _ties.ToString();
                WinStatus.Text = e.Message;
            }

            _playerWinStatusLabels[playerIndex].Text = e.Message;
            _playerWinStatusLabels[playerIndex].Visible = true;
            
            hitButton.Enabled = false;
            standButton.Enabled = false;
        }

        public void OnTableListUpdate(object sender, List<Table> tableList)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}