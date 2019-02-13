using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlapJack
{
    class Card
    {
        private string suit;
        private string face;
        private string image;

        public Card(string suit, string face)
        {
            this.suit = suit;
            this.face = face;

            setImage();

        }

        public string getSuit()
        {

            return suit;

        }

        public string getface()
        {

            return face;

        }

        public string getImage()
        {

            return image;

        }

        private void setImage()
        {
            string tFace;

            if (face.Equals("King"))
            {
                tFace = "K";
            }
            else if (face.Equals("Queen"))
            {
                tFace = "Q";
            }
            else if (face.Equals("Jack"))
            {
                tFace = "J";
            }
            else if (face.Equals("Ace"))
            {
                tFace = "A";
            }
            else
            {
                tFace = face;
            }

            image = "image/" + tFace + suit[0] + ".jpg";
        }


    }
}
