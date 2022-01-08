using BoardLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{   
    public partial class Form1 : Form // läggs enkelt till via form som skapas 
    {
        Board game = new Board();
        Button[] buttons = new Button[9];
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            game = new Board();

            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;

            //  lägg till en gemensam klickhändelse för varje knapp
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += handleButtoncklick;
                buttons[i].Tag = i;
            }
        }
        
        private void handleButtoncklick(object sender, EventArgs e)
        {
            Button clickedButton = (Button) sender;
            // MessageBox.Show("button" + clickedButton.Tag + "was clicked"); 

            // ändra värdet på spelklassen baserat på klicket
            int gameSquareNumber = (int)clickedButton.Tag;

            game.Grid[gameSquareNumber] = 1;

            updateBoard();

            if (game.isBoardFull() == true) // gör knapparna inaktiva om spelet är fullt 
            {
                MessageBox.Show("The board is full");
                disableAllButtons();
            }

            else if (game.checkForWinner() == 1) // leta efter vinnare
            {
                MessageBox.Show("Human wins!");
                disableAllButtons();
            }
            else
            {
                computerChoose(); // datorns tur
            }
        }

        private void disableAllButtons() // gör knapparna inaktiva om spelet är fullt 
        {
            foreach (var item in buttons)
            {
                item.Enabled = false;
            }
        }

        private void computerChoose()
        {
            // datorn väljer ett random nummer. uppdatera game.Grid 
            int computerTurn = rand.Next(9);
            // tar ett random nummer från datorn, tillåter inte datorn att välja en vald ruta
            while (computerTurn == -1 || game.Grid[computerTurn] != 0)
            {
                computerTurn = rand.Next(9);

                Console.WriteLine("Computer choose " + computerTurn);
            }
            game.Grid[computerTurn] = 2;
            updateBoard();

            // kolla efter vinnare
            // kolla om spelet är fullt
            if (game.isBoardFull() == true) // gör knapparna inaktiva om spelet är fullt 
            {
                MessageBox.Show("The board is full");
                disableAllButtons();
            }

            else if (game.checkForWinner() == 2) // leta efter vinnare
            {
                MessageBox.Show("Computer wins!");
                disableAllButtons();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateBoard();
        }

        private void updateBoard()
        {
            // tilldelar x eller o till texten på varje knapp baserat på värdet på spelplanen
            for (int i = 0; i < game.Grid.Length; i++) // om game.Grid är samma som 0 betyder det att knappen är tom 
            {
                if (game.Grid[i] == 0)
                {
                    buttons[i].Text = ""; // visa blank om 0 
                    buttons[i].Enabled = true;
                }
                else if (game.Grid[i] == 1) // om det är samma som ett betyder det att spelare ett har tagit platsen
                {
                    buttons[i].Text = "X"; // skriv ut X om spelare 1 har tagit en plats
                    buttons[i].Enabled = false; // inaktiverar om de är tagna
                }
                else if (game.Grid[i] == 2)
                {
                    buttons[i].Text = "O";
                    buttons[i].Enabled = false;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            game = new Board();
            enableAllButtons();

        }

        private void enableAllButtons()
        {
            foreach (var item in buttons)
            {
                item.Enabled = true;
            }

            updateBoard();
        }
    }
}
