using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SlapJack
{
    class Computer
    {
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
        }
    }
}
