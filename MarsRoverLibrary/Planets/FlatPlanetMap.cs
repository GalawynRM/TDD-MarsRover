using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverLibrary
{
    public class FlatPlanetMap : IMap
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public List<Coordinate> Obstacles { get; set; } = new List<Coordinate>();

        public void CheckBoundaries(Coordinate coordinate)
        {
            if (coordinate.X >= this.MaxX)
            {
                throw new RoverOutOfBoundariesException();
            }
            else if (coordinate.X < 0)
            {
                throw new RoverOutOfBoundariesException();
            }
            if (coordinate.Y >= this.MaxY)
            {
                throw new RoverOutOfBoundariesException();
            }
            else if (coordinate.Y < 0)
            {
                throw new RoverOutOfBoundariesException();
            }
        }
    }
}
