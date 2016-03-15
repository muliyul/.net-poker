using Blackjack.Service;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Blackjack
{
    public partial class GameWindow : Window
    {

        public GameWindow(Player player, Service.Table table) 
        {
            this.player = player;
            this.table = table;
            InitializeComponent();
            SetUpNewGame();
        }

   
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region Fields

        //Creates a new blackjack game with one player and an inital balance set through the settings designer
        private bool firstTurn;
        private Player player;
        private Service.Table table;

        #endregion

        #region Game Methods

        /// <summary>
        /// This method updates the current bet by a specified bet amount
        /// </summary>
        /// <param name="betValue"></param>
        private void Bet(decimal betValue)
        {
        }

        /// <summary>
        /// Set the "My Account" value in the UI
        /// </summary>
        private void ShowBankValue()
        {
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

            PlayerCard0.Visibility = Visibility.Hidden;
            PlayerCard1.Visibility = Visibility.Hidden;
            PlayerCard2.Visibility = Visibility.Hidden;
            PlayerCard3.Visibility = Visibility.Hidden;
            PlayerCard4.Visibility = Visibility.Hidden;
            PlayerCard5.Visibility = Visibility.Hidden;
            
        }

        /// <summary>
        /// Get the game result.  This returns an EndResult value
        /// </summary>
        /// <returns></returns>
        /*private EndResult GetGameResult()
        {
            EndResult endState= EndResult.DealerBlackJack;
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
            switch (endState)
            {
                case EndResult.DealerBust:
                    WinStatus.Content = "Dealer Bust!";
                    game.PlayerWin();
                    break;
                case EndResult.DealerBlackJack:
                    WinStatus.Content = "Dealer BlackJack!";
                    game.PlayerLose();
                    break;
                case EndResult.DealerWin:
                    WinStatus.Content = "Dealer Won!";
                    game.PlayerLose();
                    break;
                case EndResult.PlayerBlackJack:
                    WinStatus.Content = "BlackJack!";
                    game.CurrentPlayer.Balance += (game.CurrentPlayer.Bet * (decimal)2.5);
                    game.CurrentPlayer.Wins += 1;
                    break;
                case EndResult.PlayerBust:
                    WinStatus.Content = "You Bust!";
                    game.PlayerLose();
                    break;
                case EndResult.PlayerWin:
                    WinStatus.Content = "You Won!";
                    game.PlayerWin();
                    break;
                case EndResult.Push:
                    WinStatus.Content = "Push";
                    game.CurrentPlayer.Push += 1;
                    game.CurrentPlayer.Balance += game.CurrentPlayer.Bet;
                    break;
            }
            // Update the "My Record" values
            wins_label.Content = game.CurrentPlayer.Wins.ToString();
            loses_label.Content = game.CurrentPlayer.Losses.ToString();
            ties_label.Content = game.CurrentPlayer.Push.ToString();
            SetUpNewGame();
            ShowBankValue();
            WinStatus.Visibility=Visibility.Visible;
            // Check if the current player is out of money
            if (game.CurrentPlayer.Balance == 0)
            {
                MessageBox.Show("Out of Money.  Please create a new game to play again.");
                this.Close();
            }
        }*/

        #endregion

        #region Game UI Methods

        /// <summary>
        /// Set up the UI for when the game is in play after the player has hit deal game
        /// </summary>
        private void SetUpGameInPlay()
        {
            Bet10Btn.IsEnabled = false;
            Bet25Btn.IsEnabled = false;
            Bet50Btn.IsEnabled = false;
            Bet100Btn.IsEnabled = false;
            ClearBtn.IsEnabled = false;
            StandBtn.IsEnabled = true;
            HitBtn.IsEnabled = true;
            WinStatus.Visibility = Visibility.Hidden;
            TotalCardValLbl.Visibility = Visibility.Visible;
            //DealBtn.IsEnabled = false;

            if (firstTurn)
                DoubleBetBtn.IsEnabled = true;
        }

        /// <summary>
        /// Set up the UI for a new game
        /// </summary>
        private void SetUpNewGame()
        {
            //DealBtn.IsEnabled = true;
            DoubleBetBtn.IsEnabled = false;
            StandBtn.IsEnabled = false;
            HitBtn.IsEnabled = false;
            ClearBtn.IsEnabled = true;
            Bet10Btn.IsEnabled = true;
            Bet25Btn.IsEnabled = true;
            Bet50Btn.IsEnabled = true;
            Bet100Btn.IsEnabled = true;
            WinStatus.Visibility = Visibility.Hidden;
            TotalCardValLbl.Visibility = Visibility.Hidden;
            firstTurn = true;
            ShowBankValue();
        }

        /// <summary>
        /// Refresh the UI to update the player cards
        /// </summary>
        private void UpdateUIPlayerCards()
        {
            //// Update the value of the hand
            //TotalCardValLbl.Content = game.CurrentPlayer.Hand.GetSumOfHand().ToString();

            //List<Card> playerCards = game.CurrentPlayer.Hand.Cards;
            //for (int i = 0; i < playerCards.Count; i++)
            //{
            //    // Load each card from file
            //    Image card = (Image)rootV.FindName("PlayerCard" + i);
            //    LoadCard(card, playerCards[i]);
            //    card.Visibility = Visibility.Visible;
            //    //card.BringToFront();
            //}

            //List<Card> dealerCards = game.Dealer.Hand.Cards;
            //for (int i = 0; i < dealerCards.Count; i++)
            //{
            //    Image card = (Image)rootV.FindName("DealerCard" + i);
            //    LoadCard(card, dealerCards[i]);
            //    card.Visibility = Visibility.Visible;
            //}
        }

        /// <summary>
        /// Takes the card value and loads the corresponding card image from file
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="c"></param>
        private void LoadCard(Image pb, Card c)
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
                        if( c.Face.ToString().Equals(Face.Ten.ToString()) )
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
                //if (!c.IsCardUp)
               //     image.Replace(image.ToString(), cardGameImageSkinPath);
                
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
        }

        private void Hit(object sender, RoutedEventArgs e)
        {
        }

        private void DoubleBet(object sender, RoutedEventArgs e)
        {
        }

        private void ClearBet(object sender, RoutedEventArgs e)
        {
        }

        private void ReadyBtn_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
