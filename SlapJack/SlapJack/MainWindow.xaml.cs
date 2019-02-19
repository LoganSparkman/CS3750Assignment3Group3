using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Media;
using System.IO;

namespace SlapJack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// the player
        /// </summary>
        Player player;

        /// <summary>
        /// the computer player
        /// </summary>
        Computer computer;

        /// <summary>
        /// the board
        /// </summary>
        Board board;

        /// <summary>
        /// the deck
        /// </summary>
        Deck deck;
        /// <summary>
        /// Delays the computers slap then calls the slap method to see who slapped first
        /// </summary>
        BackgroundWorker computerSlapWorker = new BackgroundWorker();

        /// <summary>
        /// waits a random time before playing the computers card to simulate a real person
        /// </summary>
        BackgroundWorker computerPlayWorker = new BackgroundWorker();

        /// <summary>
        /// pauses the ui for 2 seconds to display winner of the slap
        /// </summary>
        BackgroundWorker boardWaitWorker = new BackgroundWorker();

        /// <summary>
        /// image of the back of a card
        /// </summary>
        BitmapImage carbackImage = new BitmapImage(new Uri("image/cardback.jpg", UriKind.Relative));
        
        //loading sound files
        SoundPlayer slapSound = new SoundPlayer(Properties.Resources.slap);
        SoundPlayer booSound = new SoundPlayer(Properties.Resources.boo);
        SoundPlayer applauseSound = new SoundPlayer(Properties.Resources.applause);

        //string currentStatus = "Before the game";
        bool beforeGame = true;

        public MainWindow()
        {
            InitializeComponent();
            player = new Player();
            computer = new Computer();
            deck = new Deck();
            board = new Board();

            //hide labels
            lblSlap.Visibility = Visibility.Hidden;
            lblGameOver.Visibility = Visibility.Hidden;
            lblComputerCards.Visibility = Visibility.Hidden;
            lblPlayerCards.Visibility = Visibility.Hidden;
            lblNumberOfCardsInPile.Visibility = Visibility.Hidden;

            //computer slap thread
            computerSlapWorker.DoWork += new DoWorkEventHandler(computer.slap);
            computerSlapWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(slapped);

            //computer play thread
            computerPlayWorker.DoWork += new DoWorkEventHandler(computer.playWait);
            computerPlayWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(computerPlaysCard);

            //board wait thread
            boardWaitWorker.DoWork += new DoWorkEventHandler(board.wait);
            boardWaitWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(showBoard);
        }

        /// <summary>
        /// For when the player hits space to slap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                slapSound.Play();
                if (board.totalCards > 0)
                {
                    if (board.middlePile[board.totalCards - 1].getface() == "Jack")
                    {
                        player.slappedFirst = true;

                    }

                }
   
            }

        }

        /// <summary>
        /// determines who slapped first
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slapped(object sender, RunWorkerCompletedEventArgs e)
        {

            if (player.slappedFirst)
            {
                //reset slappedFirst
                player.slappedFirst = false;

                whoSlapped("You slapped first!");
                //add the middle pile to players hand
                player.hand.addHand(board.totalCards, board.middlePile);

            }
            else // computer slapped first
            {
                whoSlapped("Computer slapped first");
                //add the middle pile to computers hand
                computer.hand.addHand(board.totalCards, board.middlePile);
            }

            //clear the board
            board.clear();
            CardImage.Source = null;

            //update labels
            lblComputerCards.Content = "Computer has " + computer.hand.totalCards + " cards.";
            lblPlayerCards.Content = "Player has " + player.hand.totalCards + " cards.";
            lblNumberOfCardsInPile.Content = "There are " + board.totalCards + " cards on the table.";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //update labels
            lblComputerCards.Content = "Computer has " + computer.hand.totalCards + " cards.";
            lblPlayerCards.Content = "Player has " + player.hand.totalCards + " cards.";
            lblNumberOfCardsInPile.Content = "There are " + board.totalCards + " cards on the table.";

            if (beforeGame)
            {
                deck.shuffle();
                for (int i = 0; i < 26; i++)
                {
                    player.hand.addCard(deck.deal());
                    computer.hand.addCard(deck.deal());
                }

                //change from start to play card
                btnMainButton.Content = "Play Card";

                lblComputerCards.Visibility = Visibility.Visible;
                lblPlayerCards.Visibility = Visibility.Visible;
                lblNumberOfCardsInPile.Visibility = Visibility.Visible;

                
                beforeGame = false;
            }
            else
            {
                Card temp = player.hand.dealCard();
                board.addCard(temp);
                BitmapImage image = new BitmapImage(new Uri(temp.getImage(), UriKind.Relative));
                CardImage.Source = image;
                BackImage.Source = carbackImage;
                

                //If Jack start computer slap
                if (temp.getface() == "Jack")
                {
                    btnMainButton.IsEnabled = false;
                    computerSlapWorker.RunWorkerAsync();
                }

                //if player lost
                if(player.hand.totalCards == 0)
                {
                    gameOver("You Lose");
                }

                btnMainButton.IsEnabled = false;
                //computers turn
                computerPlayWorker.RunWorkerAsync();
            }

            //update labels
            lblComputerCards.Content = "Computer has " + computer.hand.totalCards + " cards.";
            lblPlayerCards.Content = "Player has " + player.hand.totalCards + " cards.";
            lblNumberOfCardsInPile.Content = "There are " + board.totalCards + " cards on the table.";

        }

        /// <summary>
        /// Computer plays card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void computerPlaysCard(object sender, RunWorkerCompletedEventArgs e)
        {
            Card temp = computer.hand.dealCard();
            BitmapImage image = new BitmapImage(new Uri(temp.getImage(), UriKind.Relative));
            CardImage.Source = image;
            board.addCard(temp);

            //If Jack start computer slap
            if (temp.getface() == "Jack")
            {
                computerSlapWorker.RunWorkerAsync();
            }

            //if computer lost
            if (computer.hand.totalCards == 0)
            {
                gameOver("You Win!");
            }

            //enable the button
            btnMainButton.IsEnabled = true;

        }

        /// <summary>
        /// What happens when the game ends
        /// </summary>
        public void gameOver(string s)
        {
            //hide everything
            CardImage.Visibility = Visibility.Hidden;
            lblComputerCards.Visibility = Visibility.Hidden;
            lblPlayerCards.Visibility = Visibility.Hidden;
            lblNumberOfCardsInPile.Visibility = Visibility.Hidden;
            btnMainButton.Visibility = Visibility.Hidden;
            BackImage.Visibility = Visibility.Hidden;

            lblGameOver.Visibility = Visibility.Visible;
            lblGameOver.Content = s;

            if(s.Equals("You Win!"))
            {
                applauseSound.Play();
            }

            else
            {
                booSound.Play();
            }
        }

        /// <summary>
        /// what happens when a there is a slap
        /// </summary>
        public void whoSlapped(string s)
        {
            //hide everything
            CardImage.Visibility = Visibility.Hidden;
            lblComputerCards.Visibility = Visibility.Hidden;
            lblPlayerCards.Visibility = Visibility.Hidden;
            lblNumberOfCardsInPile.Visibility = Visibility.Hidden;
            btnMainButton.Visibility = Visibility.Hidden;
            BackImage.Visibility = Visibility.Hidden;

            lblSlap.Visibility = Visibility.Visible;
            lblSlap.Content = s;
            boardWaitWorker.RunWorkerAsync();
        }

        /// <summary>
        /// show everything but lblslap, after showing who won the slap
        /// </summary>
        public void showBoard(object sender, RunWorkerCompletedEventArgs e)
        {
            CardImage.Visibility = Visibility.Visible;
            lblComputerCards.Visibility = Visibility.Visible;
            lblPlayerCards.Visibility = Visibility.Visible;
            lblNumberOfCardsInPile.Visibility = Visibility.Visible;
            btnMainButton.Visibility = Visibility.Visible;
            BackImage.Visibility = Visibility.Visible;
            lblSlap.Visibility = Visibility.Hidden;
        }
    }
}
