using System;
using System.Collections.Generic;
using System.Text;

namespace PaperPlanes
{
    public class Player
    {
        
        public Player(string name)
        {
            Name = name;
            
        }

        public List<String> previousHits = new List<String>();

        public string Name { get; set; }
        public Board Board { get; set; }
        public Plane Plane { get; set; }

        public void DrawPlane(int startX, int startY)
        {
            Plane = new Plane();

            for (var i = startX; i < Plane.GetCoordinates().GetLongLength(0) + startX; i++)
            {
                for (var j = startY; j < Plane.GetCoordinates().GetLongLength(1) + startY; j++)
                {
                    if (Plane.GetCoordinates()[i - startX, j - startY] == 1)
                        Board.DrawPlaneSquare(i, j);
                }
            }
        }

        public void DrawBoard()
        {
            for (var i = -1; i < Board.Y; i++)
            {
                if (i != -1)
                {
                    //display left margin of board
                    Console.Write(i + " |");
                }

                for (var j = 0; j < Board.X; j++)
                {
                    if (i == -1 && j == 0)
                        Console.Write("   " + j);//display top of the board with extra margin for first char
                    else if (i == -1 && j > -1)
                        Console.Write(" " + j);//display rest of the top of the board

                    if (i >= 0 && j >= 0)
                        ConvertSquareValueToUIVal(Board.GetSquare(j, i));//draw board
                }

                if (i == -1)
                {
                    Console.WriteLine("");
                    for (var j = 0; j < Board.X; j++)
                        Console.Write("--");//display top margin
                }

                Console.WriteLine("");
            }
        }

        private void ConvertSquareValueToUIVal(int val) {
            switch (val)
            {
                case 0:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("  ");break;
                case 1:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write("  "); break;
                case 2:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write("  "); break;
                case 3:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("  "); break;
            }

            Console.BackgroundColor = ConsoleColor.Black;

            return;
        }

    }
}
