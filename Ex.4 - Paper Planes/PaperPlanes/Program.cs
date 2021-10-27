using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PaperPlanes
{
    class Program
    {
        static public void PlayerPosition(Player player)
        {
            int xPlayer, yPlayer;
            string pattern = "^([0-4],[0-5])$";
            Regex rg = new Regex(pattern);
            MatchCollection matchedInput;
            string positionPlayer;

            do
            {
                Console.WriteLine($"{player.Name} select plane position (x,y):");
                positionPlayer = Console.ReadLine();
                matchedInput = rg.Matches(positionPlayer);
            }
            while (matchedInput.Count != 1);

            var positionsPlayer = positionPlayer.Split(",");
            xPlayer = int.Parse(positionsPlayer[0]);
            yPlayer = int.Parse(positionsPlayer[1]);

            player.DrawPlane(xPlayer, yPlayer);
            player.DrawBoard();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.Clear();
            
        }

        static int[] WhereToHit(Player currentPlayer)
        {
            int x, y;
            string pattern = "^([0-7],[0-7])$";
            Regex rg = new Regex(pattern);
            MatchCollection matchedInput;
            string position;
            do
            {
                Console.WriteLine($"{currentPlayer.Name} select square to hit (x,y):");
                position = Console.ReadLine();
                matchedInput = rg.Matches(position);
            }
            while (matchedInput.Count != 1);

            currentPlayer.previousHits.Add(position);

            var positions = position.Split(",");
            x = int.Parse(positions[0]);
            y = int.Parse(positions[1]);

            int[] arr = { x, y };
            return arr;
        }

        static Player PlayerName(int playerNumber)
        {
            Console.WriteLine($"Enter player {playerNumber} name:");
            var player = new Player(Console.ReadLine());
            return player;

        }

        static void Main(string[] args)
        {
            var player1 = PlayerName(1);
            var player2 = PlayerName(2);

            var game = new Game(player1, player2);
            player1.Board = new Board(8, 8);
            player2.Board = new Board(8, 8);         

            Program.PlayerPosition(player1);
            Program.PlayerPosition(player2);

            var currentPlayer = player1;
            var otherPlayer = player2;

            while (!game.IsOver())
            {
                Console.WriteLine($"{currentPlayer.Name} press any key to start game...");
                Console.ReadKey();

                currentPlayer.DrawBoard();

                Console.WriteLine("Previous locations hit:\n---------------------");
                foreach (String position in currentPlayer.previousHits)
                {
                    Console.WriteLine("(" + position + ")");
                }
                Console.WriteLine("---------------------");

                int[] x_y = WhereToHit(currentPlayer);
                int x = x_y[0];
                int y = x_y[1];
               
                var isHit = otherPlayer.Board.DrawPlaneHit(x, y);
                Console.WriteLine(isHit ? "Target hit!" : "Missed...");

                currentPlayer = currentPlayer.Name == player1.Name ? player2 : player1;
                otherPlayer = otherPlayer.Name == player1.Name ? player2 : player1;

                Console.WriteLine("Press any key for next player...");
                Console.ReadKey();

                Console.Clear();
            }
            
            Console.WriteLine($"Game Over! {otherPlayer.Name} has won!");
            Console.WriteLine("------------------------");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

}
