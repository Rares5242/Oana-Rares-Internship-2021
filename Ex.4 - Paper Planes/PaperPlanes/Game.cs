using System;
using System.Collections.Generic;
using System.Text;

namespace PaperPlanes
{
    public class Game
    {
        public Game(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }

        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public bool IsOver()
        {
            return Player1.Board.IsPlaneDestroyed() || Player2.Board.IsPlaneDestroyed();
        }
    }
}
