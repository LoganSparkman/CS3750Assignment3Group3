using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapJack
{
    class Player
    {

        private bool hasSelectedCard;
        private int column;


        public Player()
        {
            hasSelectedCard = false;
            column = 0;
        }

        public void pickCard()
        {
            hasSelectedCard = true;
        }

        public void indicateColumn(int column)
        {
            this.column = column;
        }

        public bool getHasSelectedCard()
        {
            return hasSelectedCard;
        }

        public int getColumn()
        {
            return column;
        }
    }
}
