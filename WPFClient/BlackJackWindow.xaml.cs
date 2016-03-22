using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Blackjack.GameReference;

namespace Blackjack
{
    public partial class GameWindow : Window, IGameCallback
    {

        #region Fields

        //Creates a new blackjack game with one player and an inital balance set through the settings designer


        private bool _firstTurn;
        private PlayerData _me;

        private Table _table;
        private decimal _currentBet = 0;
        private List<Label> _playerNameLabels = new List<Label>();
        private List<Label> _playerLabelsTotalCardVal = new List<Label>();
        private List<Label> _playerBetAmountLabels = new List<Label>();
        private List<Label> _playerWinStatusLabels = new List<Label>();
        private int _ties = 0;

        private GameClient Server
        {
            get; set;
        }

        #endregion

        public GameWindow(ref PlayerData player, GameReference.Table table, GameReference.GameClient server)
        {
            _table = table;
            _me = player;
            Server = server;

            Title += " :: Logged in as " + player.Username;

            InitializeComponent();

            _playerNameLabels.Add(Player1Lb);
            _playerNameLabels.Add(Player2Lb);
            _playerNameLabels.Add(Player3Lb);
            _playerNameLabels.Add(Player4Lb);
            _playerNameLabels.Add(Player5Lb);

            _playerLabelsTotalCardVal.Add(TotalCardValLbl1);
            _playerLabelsTotalCardVal.Add(TotalCardValLbl2);
            _playerLabelsTotalCardVal.Add(TotalCardValLbl3);
            _playerLabelsTotalCardVal.Add(TotalCardValLbl4);
            _playerLabelsTotalCardVal.Add(TotalCardValLbl5);

            _playerBetAmountLabels.Add(palyer1BetLb);
            _playerBetAmountLabels.Add(palyer2BetLb);
            _playerBetAmountLabels.Add(palyer3BetLb);
            _playerBetAmountLabels.Add(palyer4BetLb);
            _playerBetAmountLabels.Add(palyer5BetLb);

            _playerWinStatusLabels.Add(WinStatusPlayer1);
            _playerWinStatusLabels.Add(WinStatusPlayer2);
            _playerWinStatusLabels.Add(WinStatusPlayer3);
            _playerWinStatusLabels.Add(WinStatusPlayer4);
            _playerWinStatusLabels.Add(WinStatusPlayer5);

            ClearTableCards();

            SetUpNewGame();
        }

        private void EndGame_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
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
            total_sum_label.Content = "$" + (_me.Bank - _currentBet);

            var player = _table.Players.Single(p => p.Username.Equals(_me.Username));
            var playerIndex = _table.Players.IndexOf(player);

            _playerBetAmountLabels[playerIndex].Content = _currentBet.ToString() + "$";
            // current_bet_label.Content = "$" + _currentBet.ToString();
        }

        /// <summary>
        /// Clear the dealer and player cards
        /// </summary>
        private void ClearTableCards()
        {

            DealerCard0.Visibility = Visibility.Hidden;
            DealerCard1.Visibility = Visibility.Hidden;
            DealerCard2.Visibility = Visibility.Hidden;
            DealerCard3.Visibility = Visibility.Hidden;
            DealerCard4.Visibility = Visibility.Hidden;
            DealerCard5.Visibility = Visibility.Hidden;

            Player1Card0.Visibility = Visibility.Hidden;
            Player1Card1.Visibility = Visibility.Hidden;
            Player1Card2.Visibility = Visibility.Hidden;
            Player1Card3.Visibility = Visibility.Hidden;
            Player1Card4.Visibility = Visibility.Hidden;
            Player1Card5.Visibility = Visibility.Hidden;

            Player2Card0.Visibility = Visibility.Hidden;
            Player2Card1.Visibility = Visibility.Hidden;
            Player2Card2.Visibility = Visibility.Hidden;
            Player2Card3.Visibility = Visibility.Hidden;
            Player2Card4.Visibility = Visibility.Hidden;
            Player2Card5.Visibility = Visibility.Hidden;

            Player3Card0.Visibility = Visibility.Hidden;
            Player3Card1.Visibility = Visibility.Hidden;
            Player3Card2.Visibility = Visibility.Hidden;
            Player3Card3.Visibility = Visibility.Hidden;
            Player3Card4.Visibility = Visibility.Hidden;
            Player3Card5.Visibility = Visibility.Hidden;

            Player4Card0.Visibility = Visibility.Hidden;
            Player4Card1.Visibility = Visibility.Hidden;
            Player4Card2.Visibility = Visibility.Hidden;
            Player4Card3.Visibility = Visibility.Hidden;
            Player4Card4.Visibility = Visibility.Hidden;
            Player4Card5.Visibility = Visibility.Hidden;

            Player5Card0.Visibility = Visibility.Hidden;
            Player5Card1.Visibility = Visibility.Hidden;
            Player5Card2.Visibility = Visibility.Hidden;
            Player5Card3.Visibility = Visibility.Hidden;
            Player5Card4.Visibility = Visibility.Hidden;
            Player5Card5.Visibility = Visibility.Hidden;

            _playerWinStatusLabels.ForEach(p => p.Content = null);
            _playerWinStatusLabels.ForEach(p => p.Visibility = Visibility.Hidden);
            WinStatusDealer.Content = null;
            WinStatusDealer.Visibility = Visibility.Hidden;
            _playerNameLabels.ForEach(pl => pl.Foreground = Brushes.White);
        }
        #endregion

        #region Game UI Methods

        /// <summary>
        /// Set up the UI for when the game is in play after the player has hit deal game
        /// </summary>
        public void SetUpGameInPlay()
        {
            Bet10Btn.IsEnabled = false;
            Bet25Btn.IsEnabled = false;
            Bet50Btn.IsEnabled = false;
            Bet100Btn.IsEnabled = false;
            ClearBtn.IsEnabled = false;
            StandBtn.IsEnabled = false;
            HitBtn.IsEnabled = false;
            WinStatus.Visibility = Visibility.Hidden;      ///////////  <-- should be on call back

            for (int i = 0; i < _table.Players.Count; ++i)
            {
                _playerLabelsTotalCardVal[i].Visibility = Visibility.Visible;
            }

            DealBtn.IsEnabled = false;

            if (_firstTurn)
                DoubleBetBtn.IsEnabled = false;
        }


        public void UpdatePlayers()
        {
            _playerNameLabels.ForEach(p => p.Content = string.Empty);
            for (int i = 0; i < _table.Players.Count; ++i)
            {
                _playerNameLabels[i].Content = _table.Players[i].Username;
            }
        }

        public void UpdatePlayersBet()
        {
          
            foreach (var playerIdx in _table.Players.FindAll(p => !p.Username.Equals(_me.Username)).Select(p => _table.Players.IndexOf(p)))
            {
                _playerBetAmountLabels[playerIdx].Content = _table.Players[playerIdx].Bet + "$";
            }
        }


        /// <summary>
        /// Set up the UI for a new game
        /// </summary>
        private void SetUpNewGame()
        {

            UpdatePlayers();
            UpdatePlayersBet();

            DealBtn.IsEnabled = true;
            DoubleBetBtn.IsEnabled = false;
            StandBtn.IsEnabled = false;
            HitBtn.IsEnabled = false;
            ClearBtn.IsEnabled = true;
            EndGameBtn.IsEnabled = true;
            Bet10Btn.IsEnabled = true;
            Bet25Btn.IsEnabled = true;
            Bet50Btn.IsEnabled = true;
            Bet100Btn.IsEnabled = true;

            WinStatus.Content = string.Empty;
            WinStatus.Visibility = Visibility.Hidden;

            _playerLabelsTotalCardVal.ForEach(p => p.Visibility = Visibility.Hidden);
            _playerBetAmountLabels.ForEach(l => l.Content = 0);

            _firstTurn = true;
            ShowBankValue();
        }

        /// <summary>
        /// Refresh the UI to update the player cards
        /// </summary>
        private void UpdateUIPlayerCards()
        {
            //// Update the value of the hand

            for (int i = 0; i < _table.Players.Count; i++)
            {
                _playerLabelsTotalCardVal[i].Content = HandValue(_table.Players[i].Hand);
                List<GameReference.Card> playerCards = _table.Players[i].Hand.Cards;
                for (int j = 0; j < playerCards.Count; j++)
                {
                    // Load each card from file
                    Image card = (Image)rootV.FindName("Player" + (i + 1) + "Card" + j);
                    LoadCard(card, playerCards[j]);
                    if (card != null)
                        card.Visibility = Visibility.Visible;

                }
            }


            List<GameReference.Card> dealerCards = _table.Dealer.Hand.Cards;

            WinStatusDealer.Content = HandValue(_table.Dealer.Hand);

            for (int i = 0; i < dealerCards.Count; i++)
            {
                Image card = (Image)rootV.FindName("DealerCard" + i);
                LoadCard(card, dealerCards[i]);
                card.Visibility = Visibility.Visible;
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
        private void LoadCard(Image pb, GameReference.Card c)
        {
            if (pb == null)
                return;
            try
            {
                StringBuilder image = new StringBuilder();

                switch (c.Suit)
                {
                    case GameReference.Suit.Diamonds:
                        image.Append("di");
                        break;
                    case GameReference.Suit.Hearts:
                        image.Append("he");
                        break;
                    case GameReference.Suit.Spades:
                        image.Append("sp");
                        break;
                    case GameReference.Suit.Clubs:
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

                image.Append(".gif");
                string cardGameImagePath = "..\\..\\Images\\Cards\\";
                string cardGameImageSkinPath = "..\\..\\Images\\Cards\\cardSkin.PNG";
                image.Insert(0, cardGameImagePath);
                //check to see if the card should be faced down or up;

                // TODO
                if (!c.IsCardUp)
                    image.Replace(image.ToString(), cardGameImageSkinPath);

                // And also here
                ImageSourceConverter imageConverter = new ImageSourceConverter();

                //big Thanks To OmriKusH Glam for helping me here!!! Good JOB M8
                pb.Source = (ImageSource)imageConverter.ConvertFromString(image.ToString());
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Card images are not loading correctly.  Make sure all card images are in the right location.");
            }
        }
        #endregion

        private void Deal(object sender, RoutedEventArgs e)
        {
            try
            {
                // If the current bet is equal to 0, ask the player to place a bet
                if ((_currentBet == 0) && (_me.Bank > 0))
                {
                    MessageBox.Show("You must place a bet before the dealer deals.", "Error", MessageBoxButton.OK);
                }
                else
                {
                    // Place the bet
                    Server.Bet(_currentBet, false);

                    Server.Deal();

                    DealBtn.IsEnabled = ClearBtn.IsEnabled = false;
                  
                }
            }
            catch (Exception NotEnoughMoneyException)
            {
                MessageBox.Show(NotEnoughMoneyException.Message);
            }
        }

        private void Bet10(object sender, RoutedEventArgs e)
        {
            Bet(10);
        }

        private void Bet25(object sender, RoutedEventArgs e)
        {
            Bet(25);
        }

        private void Bet50(object sender, RoutedEventArgs e)
        {
            Bet(50);
        }

        private void Bet100(object sender, RoutedEventArgs e)
        {
            Bet(100);
        }

        private void Stand(object sender, RoutedEventArgs e)
        {
            // Dealer should finish playing and the UI should be updated

            Server.Stand();
            HitBtn.IsEnabled = StandBtn.IsEnabled = false;
        }

        private void Hit(object sender, RoutedEventArgs e)
        {
            _firstTurn = false;
            EndGameBtn.IsEnabled = false;

            Server.Hit();
            HitBtn.IsEnabled = false;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Server.Leave();
        }

        private void DoubleBet(object sender, RoutedEventArgs e)
        {
            Server.Bet(_currentBet, true);
        }

        private void ClearBet(object sender, RoutedEventArgs e)
        {
            
            _currentBet = 0;
            ShowBankValue();
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
            var player = _table.Players.Single(p => p.Username.Equals(e.Player.Username));
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
                HitBtn.IsEnabled = true;


            _playerWinStatusLabels[playerIndex].Content = e.Message;
            _playerWinStatusLabels[playerIndex].Visibility = e.Message != null ? Visibility.Visible : Visibility.Hidden;
        }

        public void OnBet(object sender, GameArgs e)
        {
            var player = _table.Players.Single(p => p.Username.Equals(e.Player.Username));
            player.Bet = e.Amount;
            UpdatePlayersBet();
        }

        public void OnDeal(object sender, GameArgs e)
        {
            _table = e.Table;
            ClearTableCards();
            HitBtn.IsEnabled = DoubleBetBtn.IsEnabled = false;

            UpdatePlayersBet();
            UpdateUIPlayerCards();
            SetUpGameInPlay();
        }

        public void OnTableListUpdate(object sender, List<GameReference.Table> tableList)
        {
            //throw new NotImplementedException();
        }

        public void OnMyTurn(object sender, GameArgs e)
        {
            _table = e.Table;

            _playerNameLabels.ForEach(pl => pl.Foreground = Brushes.White);
            _playerNameLabels.FirstOrDefault(p => e.Player.Username.Equals(p.Content)).Foreground = Brushes.Yellow;

            if (e.Player.Username.Equals(_me.Username))
            {
                StandBtn.IsEnabled = true;
                HitBtn.IsEnabled = true;
                EndGameBtn.IsEnabled = false;
            }

            UpdateUIPlayerCards();
        }

        public void OnStand(object sender, GameArgs e)
        {

        }

        public void OnDealerPlay(object sender, GameArgs e)
        {
            WinStatusDealer.Visibility = Visibility.Visible;
            _table.Dealer.Hand = e.Player.Hand;
           
            WinStatus.Visibility = Visibility.Visible;
            UpdateUIPlayerCards();
        }

        public void OnRoundResult(object sender, GameArgs e)
        {
            _table = e.Table;
            var player = _table.Players.Single(p => p.Username.Equals(_me.Username));
            var playerIndex = _table.Players.IndexOf(player);

            _me.Bank = e.Table.Players[playerIndex].Bank;
            _me.Bet = e.Table.Players[playerIndex].Bet;
            _me.WonHands = e.Table.Players[playerIndex].WonHands;
            _me.Hand = e.Table.Players[playerIndex].Hand;
            _playerWinStatusLabels[playerIndex].Content = e.Message;

            wins_label.Content = e.Player.WonHands;
            loses_label.Content = e.Player.LostHands;
            if (e.Message.Contains("Tie"))
                _ties++;
            ties_label.Content = _ties;
            WinStatus.Content = e.Message;

            HitBtn.IsEnabled = false;
            StandBtn.IsEnabled = false;
        }

        public void OnResetTable(object sender, GameArgs e)
        {
            var xUser = e.Table.Players.Find(p => p.Username.Equals(_me.Username));

            _me.Bank        = xUser.Bank;
            _me.Bet         = xUser.Bet;
            _me.WonHands    = xUser.WonHands;
            _me.Hand        = xUser.Hand;

            ShowBankValue();  
            ClearTableCards();
            ClearBet(null, null);
            SetUpNewGame();
        }


    }
}
