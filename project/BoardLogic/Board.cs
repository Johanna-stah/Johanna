using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardLogic
{
    public class Board
    {
        public int[] Grid 
        { 
            get; set; 
        }

        public Board() // constructor
        {
            Grid = new int[9];
            // initiera grid
            // gör alla rutor tomma
            for (int i = 0; i < 9; i++)
            {
                Grid[i] = 0;
            }
        }

        public bool isBoardFull() 
        {
            bool isFull = true;
            // anta att tavlan är full. om ett undantag hittas, ändra värdet till false
            for (int i = 0; i < Grid.Length; i++)
            {
                if (Grid[i] == 0)
                {
                    isFull = false;
                }
            }

            return isFull;
        }

        public int checkForWinner()
        {
            //skriver ut 0 om ingen vinner, skriver ut spelarens nummer om dom vann.

            //första raden
            if (Grid[0] == Grid[1] && Grid[1] == Grid[2])
            {
                return Grid[0];
            }
            //andra raden
            if (Grid[3] == Grid[4] && Grid[4] == Grid[5])
            {
                return Grid[3];
            }
            //tredje raden
            if (Grid[6] == Grid[7] && Grid[7] == Grid[8])
            {
                return Grid[6];
            }
            //första columnen
            if (Grid[0] == Grid[3] && Grid[3] == Grid[6])
            {
                return Grid[0];
            }
            //andra columnen
            if (Grid[1] == Grid[4] && Grid[4] == Grid[7])
            {
                return Grid[1];
            }
            //tredje columnen
            if (Grid[2] == Grid[5] && Grid[5] == Grid[8])
            {
                return Grid[2];
            }
            //första diagonal
            if (Grid[0] == Grid[4] && Grid[4] == Grid[8])
            {
                return Grid[0];
            }
            //andra diagonal
            if (Grid[2] == Grid[4] && Grid[4] == Grid[6])
            {
                return Grid[2];
            }

            return 0;
        }

    }
}
