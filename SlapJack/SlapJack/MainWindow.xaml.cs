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

        Computer computer;

        Board board;

        Deck deck;
        /// <summary>
        /// Delays the computers slap then calls the slap method to see who slapped first
        /// </summary>
        BackgroundWorker computerSlapWorker = new BackgroundWorker();

        BackgroundWorker computerPlayWorker = new BackgroundWorker();

        BitmapImage carbackImage = new BitmapImage(new Uri("image/cardback.jpg", UriKind.Relative));

        string currentStatus = "Before the game";

        public MainWindow()
        {
            InitializeComponent();
            player = new Player();
            computer = new Computer();
            deck = new Deck();
            board = new Board();

            //computer slap thread
            computerSlapWorker.DoWork += new DoWorkEventHandler(computer.slap);
            computerSlapWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(slapped);

            //computer play thread
            computerPlayWorker.DoWork += new DoWorkEventHandler(computer.playWait);
            computerPlayWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(computerPlaysCard);
        }

        /// <summary>
        /// For when the play hits space to slap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
                if (board.middlePile[board.totalCards].getface() == "Jack")
                    player.slappedFirst = true;

            } //for testing
            else if (e.Key == Key.S)
                computerSlapWorker.RunWorkerAsync();

        }

        /// <summary>
        /// determines who slapped first
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slapped(object sender, RunWorkerCompletedEventArgs e)
        {
            //enable the button
            btnMainButton.IsEnabled = true;

            if (player.slappedFirst)
            {
                //reset slappedFirst
                player.slappedFirst = false;

                //add the middle pile to players hand
                player.hand.addHand(board.totalCards, board.middlePile);

                //for testing
                MessageBox.Show("player");

            }
            else // computer slapped first
            {
                //add the middle pile to computers hand
                computer.hand.addHand(board.totalCards, board.middlePile);

                //for testing
                MessageBox.Show("PC");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //update labels
            lblComputerCards.Content = "Computer has " + computer.hand.totalCards + " cards.";
            lblPlayerCards.Content = "Player has " + player.hand.totalCards + " cards.";
            lblNumberOfCardsInPile.Content = "There are " + board.totalCards + " cards on the table.";

            if (currentStatus == "Before the game")
            {
                deck.shuffle();
                for (int i = 0; i < 26; i++)
                {
                    player.hand.addCard(deck.deal());
                    computer.hand.addCard(deck.deal());
                }

                //change from start to play card
                btnMainButton.Content = "Play Card";

                currentStatus = "Game";
            }
            else
            {
                Card temp = player.hand.dealCard();
                BitmapImage image = new BitmapImage(new Uri(temp.getImage(), UriKind.Relative));
                CardImage.Source = image;
                BackImage.Source = carbackImage;
                board.addCard(temp);

                //If Jack start computer slap
                if (temp.getface() == "Jack")
                {
                    computerSlapWorker.RunWorkerAsync();
                    btnMainButton.IsEnabled = false;
                }

                btnMainButton.IsEnabled = false;
                //computers turn
                computerPlayWorker.RunWorkerAsync();
            }

            //update labels
            lblComputerCards.Content = "Computer has " + computer.hand.totalCards + " cards.";
            lblPlayerCards.Content = "Player has " + player.hand.totalCards + " cards.";
            lblNumberOfCardsInPile.Content = "There are " + board.totalCards + " cards on the table.";

            /*else if (currentStatus == "Computer Turn")
            {
                Card temp = player.hand.dealCard();
                BitmapImage image = new BitmapImage(new Uri(temp.getImage(), UriKind.Relative));
                CardImage.Source = image;
                BackImage.Source = carbackImage;
                board.addCard(temp);

                //If Jack start computer slap
                if (temp.getface() == "Jack")
                {
                    computerSlapWorker.RunWorkerAsync();
                    btnMainButton.IsEnabled = false;
                }


                lblComputerCards.Content = "Computer has " + computer.hand.totalCards + " cards.";
                lblPlayerCards.Content = "Player has " + player.hand.totalCards + " cards.";
                lblNumberOfCardsInPile.Content = "There are " + board.totalCards + " cards on the table.";
                currentStatus = "Player Turn";
            }*/
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
            BackImage.Source = carbackImage;
            board.addCard(temp);

            //If Jack start computer slap
            if (temp.getface() == "Jack")
            {
                computerSlapWorker.RunWorkerAsync();
                btnMainButton.IsEnabled = false;
            }
            else
                btnMainButton.IsEnabled = true;

        }

    }
}
