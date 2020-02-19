using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverLibrary
{
    public interface IMap
    {
        int MaxX { get; set; }
        int MaxY { get; set; }

        void CheckBoundaries(Coordinate coordinate);

        List<Coordinate> Obstacles { get; set; }
    }
}
