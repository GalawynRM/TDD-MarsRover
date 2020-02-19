using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverLibrary
{
    public interface IRover
    {
        Position Position { get; set; }
        void SetLandingPoint(int x, int y, char direction);
        void SetLandingPoint(Position position);
        int ExecuteCommands(char[] commands);    
    }
}