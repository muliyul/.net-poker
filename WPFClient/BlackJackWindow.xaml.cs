using BlackJack;
using BlackJack.CardGameFramework;
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
using Blackjack.GameReference;

namespace Blackjack
{
    public partial class GameWindow : Window, IGameCallback
    {

        #region Fields

        //Creates a new blackjack game with one player and an inital balance set through the settings designer


        private bool _firstTurn;
        private PlayerData _player;

        private GameReference.Table _table;
        private decimal _currentBet;
        private List<Label> _playerNameLabels = new List<Label>();
        private List<Label> _playerLabelsTotalCardVal = new List<Label>();
        private List<Label> _playerBetAmountLabels = new List<Label>();
        private List<Label> _playerWinStatusLabels = new List<Label>();
        private GameReference.GameClient _server;
       
        #endregion

        public GameWindow(PlayerData player, GameReference.Table table, GameReference.GameClient server)
        {
            this._player = player;
            this._table = table;
            _server = server;
       
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

          
            ClearTable();

            SetUpNewGame();
        }

      

        private void EndGame_Click(object sender, RoutedEventArgs e)
        {
            _server.Leave();
            
            this.Close();
            
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
            total_sum_label.Content = "$" + (_player.Bank - Convert.ToDouble(_currentBet));

            var player = _table.Players.SingleOrDefault(p => p.Username == _player.Username);
            var playerIndex = _table.Players.IndexOf(player);

            _playerBetAmountLabels[playerIndex].Content = _currentBet.ToString() + "$";
            // current_bet_label.Content = "$" + _currentBet.ToString();
        }

        /// <summary>
        /// Clear the dealer and player cards
        /// </summary>
        private void ClearTable()
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

            _playerWinStatusLabels.ForEach(p => p.Visibility = Visibility.Hidden);
            WinStatusDealer.Visibility = Visibility.Hidden;
        }

        

        /// <summary>
        /// Get the game result.  This returns an EndResult value
        /// </summary>
        /// <returns></returns>
        private EndResult GetGameResult()
        {
            EndResult endState = EndResult.DealerBlackJack;
            //// Check for blackjack
            //if (game.Dealer.Hand.NumCards == 2 && game.Dealer.HasBlackJack())
            //{
            //    endState = EndResult.DealerBlackJack;
            //}
            //// Check if the dealer has bust
            //else if (game.Dealer.HasBust())
            //{
            //    endState = EndResult.DealerBust;
            //}
            //else if (game.Dealer.Hand.CompareFace(game.CurrentPlayer.Hand) > 0)
            //{
            //    //dealer wins
            //    endState = EndResult.DealerWin;
            //}
            //else if (game.Dealer.Hand.CompareFace(game.CurrentPlayer.Hand) == 0)
            //{
            //    // push
            //    endState = EndResult.Push;
            //}
            //else
            //{
            //    // player wins
            //    endState = EndResult.PlayerWin;
            //}
            return endState;
        }

        /// <summary>
        /// Takes an EndResult value and shows the resulting game ending in the UI
        /// </summary>
        /// <param name="endState"></param>
        private void EndGame(EndResult endState)
        {
            //switch (endState)
            //{
            //    case EndResult.DealerBust:
            //        WinStatus.Content = "Dealer Bust!";
            //        game.PlayerWin();
            //        break;
            //    case EndResult.DealerBlackJack:
            //        WinStatus.Content = "Dealer BlackJack!";
            //        game.PlayerLose();
            //        break;
            //    case EndResult.DealerWin:
            //        WinStatus.Content = "Dealer Won!";
            //        game.PlayerLose();
            //        break;
            //    case EndResult.PlayerBlackJack:
            //        WinStatus.Content = "BlackJack!";
            //        game.CurrentPlayer.Balance += (game.CurrentPlayer.Bet * (decimal)2.5);
            //        game.CurrentPlayer.Wins += 1;
            //        break;
            //    case EndResult.PlayerBust:
            //        WinStatus.Content = "You Bust!";
            //        game.PlayerLose();
            //        break;
            //    case EndResult.PlayerWin:
            //        WinStatus.Content = "You Won!";
            //        game.PlayerWin();
            //        break;
            //    case EndResult.Push:
            //        WinStatus.Content = "Push";
            //        game.CurrentPlayer.Push += 1;
            //        game.CurrentPlayer.Balance += game.CurrentPlayer.Bet;
            //        break;
            //}
            //// Update the "My Record" values
            //wins_label.Content = game.CurrentPlayer.Wins.ToString();
            //loses_label.Content = game.CurrentPlayer.Losses.ToString();
            //ties_label.Content = game.CurrentPlayer.Push.ToString();
            //SetUpNewGame();
            //ShowBankValue();
            //WinStatus.Visibility=Visibility.Visible;
            //// Check if the current player is out of money
            //if (game.CurrentPlayer.Balance == 0)
            //{
            //    MessageBox.Show("Out of Money.  Please create a new game to play again.");
            //    this.Close();
            //}
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
            for (int i = 0; i < _table.Players.Count; ++i)
            {
                _playerNameLabels[i].Content = _table.Players[i].Username;
            }
        }

        public void UpdatePlayersBet()
        {
            for (int i = 1; i < _table.Players.Count; ++i)
            {
                _playerBetAmountLabels[i].Content = _table.Players[i].Bet + "$";

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
            Bet10Btn.IsEnabled = true;
            Bet25Btn.IsEnabled = true;
            Bet50Btn.IsEnabled = true;
            Bet100Btn.IsEnabled = true;
           
            WinStatus.Visibility = Visibility.Hidden;

            _playerLabelsTotalCardVal.ForEach(p => p.Visibility = Visibility.Hidden);

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
                _playerLabelsTotalCardVal[i].Content = HandValue(_table.Players[i].Hand.Cards);
                List<GameReference.Card> playerCards = _table.Players[i].Hand.Cards;
                for (int j = 0; j < playerCards.Count; j++)
                {
                    // Load each card from file
                    Image card = (Image)rootV.FindName("Player" + (i+1) + "Card" + j);
                    LoadCard(card, playerCards[j]);
                    card.Visibility = Visibility.Visible;

                }
            }


            List<GameReference.Card> dealerCards = _table.Dealer.Hand.Cards;

            WinStatusDealer.Content = HandValue(_table.Dealer.Hand.Cards);

            for (int i = 0; i < dealerCards.Count; i++)
            {
                Image card = (Image)rootV.FindName("DealerCard" + i);
                LoadCard(card, dealerCards[i]);
                card.Visibility = Visibility.Visible;
            }
        }

      
        private int HandValue(List<GameReference.Card> cards)
        {
            int sum = cards.Sum(card => card.Value);
            int aces = cards.Count(card => card.Face == Face.Ace);

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
                if ((_currentBet == 0) && (_player.Bank > 0))
                {
                    MessageBox.Show("You must place a bet before the dealer deals.", "Error", MessageBoxButton.OK);
                }
                else
                {


                    // Place the bet
                    _server.Bet(_currentBet, false);

                    _server.Deal();
                    // shoud be call back to it ShowBankValue();

                    // Clear the table, set up the UI for playing a game, and deal a new game


                    // Check see if the current player has blackjack
                    // if (player.HasBlackJack())
                    // {
                    //     EndGame(EndResult.PlayerBlackJack);
                    // }
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
         
            _server.Stand();
          
        }

        private void Hit(object sender, RoutedEventArgs e)
        {
            _firstTurn = false;
           
            _server.Hit();
           

        
        }

        private void DoubleBet(object sender, RoutedEventArgs e)
        {

            _server.Bet(_currentBet, true);
            //try
            //{
            //    //Double the player's bet amount
            //    game.CurrentPlayer.DoubleDown();
            //    UpdateUIPlayerCards();
            //    ShowBankValue();

            //    //Make sure that the player didn't bust
            //    if (game.CurrentPlayer.HasBust())
            //    {
            //        EndGame(EndResult.PlayerBust);
            //    }
            //    else
            //    {
            //        // Otherwise, let the dealer finish playing
            //        game.DealerPlay();
            //        UpdateUIPlayerCards();
            //        EndGame(GetGameResult());
            //    }
            //}
            //catch (Exception NotEnoughMoneyException)
            //{
            //    MessageBox.Show(NotEnoughMoneyException.Message);
            //}
        }

        private void ClearBet(object sender, RoutedEventArgs e)
        {
            //Clear the bet amount
            //game.CurrentPlayer.ClearBet();
            // await LoginWindow.GameServer.ClearBetAsync();
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
            var player = _table.Players.SingleOrDefault(p => p.Username == e.Player.Username);
            _table.Players.Remove(player);
            UpdatePlayers();

        }

        public void OnHit(object sender, GameArgs e)
        {
            var player = _table.Players.SingleOrDefault(p => p.Username == e.Player.Username);
            player.Hand.Cards.Add(e.Card);
            UpdateUIPlayerCards();
        }

        public void OnBet(object sender, GameArgs e)
        {
            var player = _table.Players.SingleOrDefault(p => p.Username == e.Player.Username);
            player.Bet = e.Amount;
            UpdatePlayersBet();
        }

        public void OnStatus(object sender, GameArgs e)
        {
            var player = _table.Players.SingleOrDefault(p => p.Username == e.Player.Username);
            var playerIndex = _table.Players.IndexOf(player);
            _playerWinStatusLabels[playerIndex].Content = (string)sender;
            _playerWinStatusLabels[playerIndex].Visibility = Visibility.Visible;

            StandBtn.IsEnabled = false;
            HitBtn.IsEnabled = false;
            EndGameBtn.IsEnabled = true;
        }

        public void OnDeal(object sender, GameArgs e)
        {
            _table = e.Table;
            ClearTable();
            HitBtn.IsEnabled = false;
            DoubleBetBtn.IsEnabled = false;

            UpdatePlayersBet();
            UpdateUIPlayerCards();
        }

        public void OnNewTableCreated(object sender, List<GameReference.Table> tableList)
        {
            throw new NotImplementedException();
        }

        public void OnMyTurn(object sender, GameArgs e)
        {
          

            _table = e.Table;

            StandBtn.IsEnabled = true;
            HitBtn.IsEnabled = true;
            EndGameBtn.IsEnabled = false;

            UpdateUIPlayerCards();
        }

        public void OnStand(object sender, GameArgs e)
        {
            
        }
        public void OnDealerPlay(object sender, GameArgs e)
        {
            WinStatusDealer.Visibility = Visibility.Visible;
            _table.Dealer.Hand = e.Player.Hand;
            if(HandValue(_table.Dealer.Hand.Cards) <= 21)
            {
                
                
            } else
            {
                WinStatus.Content = "Dealer Bust!";
            }
            WinStatus.Visibility = Visibility.Visible;
            UpdateUIPlayerCards();
        }

        public void OnResetTable(object sender, GameArgs e)
        {

            ClearTable();
            SetUpNewGame();
        }
    }
}
