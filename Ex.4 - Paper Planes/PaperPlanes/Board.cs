using System;
using System.Collections.Generic;
using System.Text;

namespace PaperPlanes
{
    public class Board
    {
        public int X;
        public int Y;

        private int[,] board;

        public Board(int x, int y)
        {
            X = x;
            Y = y;

            board = new int[x, y];

            //initialize board values
            for (var i = 0; i < x; i++)
            {
                for (var j = 0; j < y; j++)
                {
                    board[i, j] = 0;
                }
            }
        }

        //returns all squares
        public int[,] GetSquares()
        {
            return board;
        }

        //returns square value
        public int GetSquare(int x, int y)
        {
            return board[x,y];
        }

        public void DrawPlaneSquare(int x, int y)
        {
                board[x, y] = (int)Enums.SquareType.PlaneSquare;         
        }

        public bool DrawPlaneHit(int x, int y)
        {
            if (board[x, y] == (int)Enums.SquareType.PlaneSquare)
                board[x, y] = (int)Enums.SquareType.PlaneHit;
            else if(board[x, y] == (int)Enums.SquareType.Empty)
                board[x, y] = (int)Enums.SquareType.PlaneMiss;

            return board[x, y] == (int)Enums.SquareType.PlaneHit;
        }

        //plane is destroyed on 3 hits
        public bool IsPlaneDestroyed()
        {
            var destroyedCount = 0;

            for (var i = 0; i < X; i++)
            {
                for (var j = 0; j < Y; j++)
                {
                    if (board[i, j] == (int)Enums.SquareType.PlaneHit) destroyedCount++;

                    if (destroyedCount >= 3)
                        return true;
                }
            }

            return false;
        }
    }
}
