using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverLibrary
{
    public class Rover : IRover
    {
        private SpherePlanetMap _map;
        public Position Position { get; set; }

        public Rover(SpherePlanetMap map)
        {
            _map = map;
        }

        private bool Probe(Coordinate coordinate)
        {
            return _map.Obstacles.Contains(coordinate);
        }

        private void MoveForward()
        {
            Coordinate newCoordinate = null;
            switch (Position.Direction)
            {
                case 'N':
                    newCoordinate = new Coordinate()
                    {
                        X = Position.X,
                        Y = Position.Y + 1
                    };
                    _map.CheckBoundaries(newCoordinate);
                    if (Probe(newCoordinate))
                    {
                        throw new RoverObstacleException();
                    }
                    Position.CopyFromCoordinate(newCoordinate);
                    break;
                case 'S':
                    newCoordinate = new Coordinate()
                    {
                        X = Position.X,
                        Y = Position.Y - 1
                    };
                    _map.CheckBoundaries(newCoordinate);
                    if (Probe(newCoordinate))
                    {
                        throw new RoverObstacleException();
                    }
                    Position.CopyFromCoordinate(newCoordinate);
                    break;
                case 'E':
                    newCoordinate = new Coordinate()
                    {
                        X = Position.X + 1,
                        Y = Position.Y
                    };
                    _map.CheckBoundaries(newCoordinate);
                    if (Probe(newCoordinate))
                    {
                        throw new RoverObstacleException();
                    }
                    Position.CopyFromCoordinate(newCoordinate);
                    break;
                case 'W':
                    newCoordinate = new Coordinate()
                    {
                        X = Position.X - 1,
                        Y = Position.Y
                    };
                    _map.CheckBoundaries(newCoordinate);
                    if (Probe(newCoordinate))
                    {
                        throw new RoverObstacleException();
                    }
                    Position.CopyFromCoordinate(newCoordinate);
                    break;
                default:
                    throw new RoverUnknownCommandException();
            }
        }

        private void MoveBackward()
        {
            Coordinate newCoordinate = null;
            switch (Position.Direction)
            {
                case 'N':
                    newCoordinate = new Coordinate()
                    {
                        X = Position.X,
                        Y = Position.Y - 1
                    };
                    _map.CheckBoundaries(newCoordinate);
                    if (Probe(newCoordinate))
                    {
                        throw new RoverObstacleException();
                    }
                    Position.CopyFromCoordinate(newCoordinate);
                    break;
                case 'S':
                    newCoordinate = new Coordinate()
                    {
                        X = Position.X,
                        Y = Position.Y + 1
                    };
                    _map.CheckBoundaries(newCoordinate);
                    if (Probe(newCoordinate))
                    {
                        throw new RoverObstacleException();
                    }
                    Position.CopyFromCoordinate(newCoordinate);
                    break;
                case 'E':
                    newCoordinate = new Coordinate()
                    {
                        X = Position.X - 1,
                        Y = Position.Y
                    };
                    _map.CheckBoundaries(newCoordinate);
                    if (Probe(newCoordinate))
                    {
                        throw new RoverObstacleException();
                    }
                    Position.CopyFromCoordinate(newCoordinate);
                    break;
                case 'W':
                    newCoordinate = new Coordinate()
                    {
                        X = Position.X + 1,
                        Y = Position.Y
                    };
                    _map.CheckBoundaries(newCoordinate);
                    if (Probe(newCoordinate))
                    {
                        throw new RoverObstacleException();
                    }
                    Position.CopyFromCoordinate(newCoordinate);
                    break;
                default:
                    throw new RoverUnknownCommandException();
            }
        }

        private void TurnLeft()
        {
            switch (Position.Direction)
            {
                case 'N':
                    Position.Direction = 'W';
                    break;
                case 'W':
                    Position.Direction = 'S';
                    break;
                case 'S':
                    Position.Direction = 'E';
                    break;
                case 'E':
                    Position.Direction = 'N';
                    break;
                default:
                    break;
            }
        }
        private void TurnRight()
        {
            switch (Position.Direction)
            {
                case 'N':
                    Position.Direction = 'E';
                    break;
                case 'E':
                    Position.Direction = 'S';
                    break;
                case 'S':
                    Position.Direction = 'W';
                    break;
                case 'W':
                    Position.Direction = 'N';
                    break;
                default:
                    break;
            }
        }

        public int ExecuteCommands(char[] commands)
        {
            int output = 0;
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'F':
                        MoveForward();
                        output++;
                        break;
                    case 'B':
                        MoveBackward();
                        output++;
                        break;
                    case 'R':
                        TurnRight();
                        output++;
                        break;
                    case 'L':
                        TurnLeft();
                        output++;
                        break;
                    default:
                        throw new RoverUnknownCommandException();
                }
            }
            return output;
        }

        public void SetLandingPoint(int x, int y, char direction)
        {
            this.Position = new Position() { X = x, Y = y, Direction = direction };
            if(_map.Obstacles.Contains(this.Position as Coordinate))
            {
                throw new RoverObstacleException();
            }
        }

        public void SetLandingPoint(Position position)
        {
            this.Position = position;
            if (_map.Obstacles.Contains(this.Position as Coordinate))
            {
                throw new RoverObstacleException();
            }
        }
    }
}
