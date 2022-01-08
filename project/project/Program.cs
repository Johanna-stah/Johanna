using BoardLogic;
using System;

namespace TicTacToe // namespace för projekt
{
    internal class Program
    {
        // Board spara data för spelet
        static Board game = new Board();
        static void Main(string[] args)
        {
            int userTurn = -1;
            int computerTurn = -1;
            Random rand = new Random(); //ger datorn en slump nummer som läggs in på spelet

            while (game.checkForWinner() == 0)
            {

                // tillåter inte en att välja en vald ruta
                while (userTurn == -1 || game.Grid[userTurn] != 0)
                {
                    Console.WriteLine("Enter a number between 0 to 8");
                    userTurn = int.Parse(Console.ReadLine());
                    Console.WriteLine("You typed " + userTurn);
                }
                game.Grid[userTurn] = 1;

                // om spelet är fullt avsulta
                if (game.isBoardFull())
                    break;

                // tar ett random nummer från datorn, tillåter inte datorn att välja en vald ruta
                while (computerTurn == -1 || game.Grid[computerTurn] != 0)
                {
                    computerTurn = rand.Next(8);
                    Console.WriteLine("Computer choose " + computerTurn);
                }
                game.Grid[computerTurn] = 2;

                // om spelet är fullt avsulta
                if (game.isBoardFull())
                    break;

                // visar spelet
                printBoard();
            }

            // while är klart
            Console.WriteLine("Game is over. Player " + game.checkForWinner() + " won the game!");
            Console.ReadLine();
        }



        private static void printBoard()
        {
            for (int i = 0; i < game.Grid.Length; i++) // räknar upp en för varje loop upp till 9
            {   // skiv ut planen
                // Console.WriteLine("Square " + i + " contains " + Board[i]); // skriver ut meddelande 
                // skriv ut x eller o för varje ruta
                // 0 betyder tagen. 1 betyder spelare 1(x) 2 betyder spelare 2(O)

                if (game.Grid[i] == 0)
                {
                    Console.Write(".");
                }
                if (game.Grid[i] == 1)
                {
                    Console.Write("x");
                }
                if (game.Grid[i] == 2)
                {
                    Console.Write("O");
                }

                // skriv ut ny rad för varje 3 tecken
                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
