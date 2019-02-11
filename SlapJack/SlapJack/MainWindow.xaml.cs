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

        /// <summary>
        /// Delays the computers slap then calls the slap method to see who slapped first
        /// </summary>
        BackgroundWorker computerSlapWorker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();
            player = new Player();
            //computer = new Computer();

            //computer thread
            computerSlapWorker.DoWork += new DoWorkEventHandler(computer.slap);
            computerSlapWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(slapped);
        }

        /// <summary>
        /// For when the play hits space to slap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                //if can slap board
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
            if(player.slappedFirst)
            {
                //reset slappedFirst
                player.slappedFirst = false;

                //for testing
                MessageBox.Show("player");

            }
            else // computer slapped first
            {
                //for testing
                MessageBox.Show("PC");
            }
        }

    }
}
