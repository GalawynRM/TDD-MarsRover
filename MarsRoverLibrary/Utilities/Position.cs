using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverLibrary
{
    public class Position: Coordinate
    {
        public char Direction { get; set; }

        public override bool Equals(object obj)
        {
            Position Obj = (Position)obj;
            return base.Equals(obj) && Obj.Direction == this.Direction;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void CopyFromCoordinate(Coordinate coord)
        {
            this.X = coord.X;
            this.Y = coord.Y;
        }
    }
}
