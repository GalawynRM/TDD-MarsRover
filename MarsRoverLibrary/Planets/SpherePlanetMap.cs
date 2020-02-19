using System;
using System.Collections.Generic;
using System.Text;


namespace MarsRoverLibrary
{
    public class SpherePlanetMap : IMap
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public List<Coordinate> Obstacles { get; set; } = new List<Coordinate>();

        public SpherePlanetMap()
        {

        }

        public void CheckBoundaries(Coordinate coordinate)
        {

            if (coordinate.X >= this.MaxX)
            {
                coordinate.X = 0;
            }
            else if (coordinate.X < 0)
            {
                coordinate.X = this.MaxX - 1;
            }
            if (coordinate.Y >= this.MaxY)
            {
                coordinate.Y = 0;
            }
            else if (coordinate.Y < 0)
            {
                coordinate.Y = this.MaxY - 1;
            }

        }
    }
}