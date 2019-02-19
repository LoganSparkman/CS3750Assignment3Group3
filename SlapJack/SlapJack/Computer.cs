using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SlapJack
{
    class Computer
    {

        SoundPlayer slapSound = new SoundPlayer(Properties.Resources.slap);

        /// <summary>
        /// The computers hand/cards
        /// </summary>
        public Hand hand;

        public Computer()
        {
            hand = new Hand();
        }

        /// <summary>
        /// time computer waits to slap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void slap(object sender, DoWorkEventArgs e)
        {
            Random rnd = new Random();
            int waitTime = rnd.Next(300, 1000);
            Thread.Sleep(waitTime);

            //slap sound
            slapSound.Play();
            Thread.Sleep(200); //to look more natural

        }

        /// <summary>
        /// time computer waits to play a card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void playWait(object sender, DoWorkEventArgs e)
        {
            Random rnd = new Random();
            int waitTime = rnd.Next(1000, 2000);
            Thread.Sleep(waitTime);
        }
    }
}
