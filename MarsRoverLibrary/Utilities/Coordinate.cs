using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverLibrary
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            Coordinate Obj = (Coordinate)obj;
            return Obj.X == this.X && Obj.Y == this.Y;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
