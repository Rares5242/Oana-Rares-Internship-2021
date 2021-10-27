using System;
using System.Collections.Generic;
using System.Text;

namespace PaperPlanes
{
    public class Plane
    {
        private int[,] Coordinates;

        public int[,] GetCoordinates()
        {
            Coordinates = new int[4, 3];
            Coordinates[0, 0] = 0;
            Coordinates[0, 1] = 1;
            Coordinates[0, 2] = 0;
            Coordinates[1, 0] = 1;
            Coordinates[1, 1] = 1;
            Coordinates[1, 2] = 1;
            Coordinates[2, 0] = 0;
            Coordinates[2, 1] = 1;
            Coordinates[2, 2] = 0;
            Coordinates[3, 0] = 1;
            Coordinates[3, 1] = 1;
            Coordinates[3, 2] = 1;

            return Coordinates;
        }
    }
}
