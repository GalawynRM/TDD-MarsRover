using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverLibrary;
namespace RoverTest
{
    public class RoverTest
    {
        private IRover rover;
        private SpherePlanetMap mars;

        //[Test]
        //public void FrameworkTest()
        //{
        //    Assert.IsTrue(true);
        //}

        [SetUp]
        public void SetUp()
        {

            mars = new SpherePlanetMap()
            {
                MaxX = 100,
                MaxY = 100,
                Obstacles = new List<Coordinate>()
                {
                    new Coordinate() { X = 4,Y = 4 }
                }
            };
            rover = new Rover(mars);
        }

        [Test]
        public void ShouldLand()
        {
            Position landing = new Position() { X = 0, Y = 0, Direction = 'N' };

            rover.SetLandingPoint(landing);

            Assert.AreEqual(landing, rover.Position);
        }

        [Test]
        public void ShouldLandCoordinates()
        {
            Position landing = new Position() { X = 0, Y = 0, Direction = 'N' };

            rover.SetLandingPoint(landing.X, landing.Y, landing.Direction);

            Assert.AreEqual(landing, rover.Position);
        }

        [Test]
        public void ShouldLandOnObstacle()
        {
            Coordinate obstacle = mars.Obstacles.First();
            Position landing = new Position() { X = obstacle.X, Y = obstacle.Y, Direction = 'N' };

            Assert.Throws(typeof(RoverObstacleException), () => { rover.SetLandingPoint(landing); });
        }

        [Test]
        public void ShouldLandCoordinatesOnObstacle()
        {
            Coordinate obstacle = mars.Obstacles.First();
            Position landing = new Position() { X = obstacle.X, Y = obstacle.Y, Direction = 'N' };

            Assert.Throws(typeof(RoverObstacleException), () => { rover.SetLandingPoint(landing.X, landing.Y, landing.Direction); });
        }

        [Test]
        public void FromNorthCouldTurnLeft()
        {
            string commands = "L";
            Position landing = new Position() { X = 0, Y = 0, Direction = 'N' };
            Position expected = new Position() { X = 0, Y = 0, Direction = 'W' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands(commands.ToCharArray());

            Assert.AreEqual(expected, rover.Position);

            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void FromWestCouldTurnLeft()
        {
            string commands = "L";
            Position landing = new Position() { X = 0, Y = 0, Direction = 'W' };
            Position expected = new Position() { X = 0, Y = 0, Direction = 'S' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands(commands.ToCharArray());

            Assert.AreEqual(expected, rover.Position);

            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void FromSouthCouldTurnLeft()
        {
            string commands = "L";
            Position landing = new Position() { X = 0, Y = 0, Direction = 'S' };
            Position expected = new Position() { X = 0, Y = 0, Direction = 'E' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands(commands.ToCharArray());

            Assert.AreEqual(expected, rover.Position);

            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void FromEastCouldTurnLeft()
        {
            string commands = "L";
            Position landing = new Position() { X = 0, Y = 0, Direction = 'E' };
            Position expected = new Position() { X = 0, Y = 0, Direction = 'N' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands(commands.ToCharArray());

            Assert.AreEqual(expected, rover.Position);
            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void FromNorthCouldTurnRight()
        {
            string commands = "R";
            Position landing = new Position() { X = 0, Y = 0, Direction = 'N' };
            Position expected = new Position() { X = 0, Y = 0, Direction = 'E' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands(commands.ToCharArray());

            Assert.AreEqual(expected, rover.Position);
            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void FromEastCouldTurnRight()
        {
            string commands = "R";
            Position landing = new Position() { X = 0, Y = 0, Direction = 'E' };
            Position expected = new Position() { X = 0, Y = 0, Direction = 'S' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands("R".ToCharArray());

            Assert.AreEqual(expected, rover.Position);
            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void FromSouthCouldTurnRight()
        {
            string commands = "R";
            Position landing = new Position() { X = 0, Y = 0, Direction = 'S' };
            Position expected = new Position() { X = 0, Y = 0, Direction = 'W' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands("R".ToCharArray());

            Assert.AreEqual(expected, rover.Position);
            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void FromWestCouldTurnRight()
        {
            string commands = "R";
            Position landing = new Position() { X = 0, Y = 0, Direction = 'W' };
            Position expected = new Position() { X = 0, Y = 0, Direction = 'N' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands("R".ToCharArray());

            Assert.AreEqual(expected, rover.Position);
            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void CouldFullRotationLeft()
        {
            string commands = "LLLL";
            Position landing = new Position() { X = 0, Y = 0, Direction = 'W' };
            Position expected = new Position() { X = 0, Y = 0, Direction = 'W' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands(commands.ToCharArray());

            Assert.AreEqual(expected, rover.Position);
            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void CouldFullRotationRight()
        {
            string commands = "RRRR";
            Position landing = new Position() { X = 0, Y = 0, Direction = 'W' };
            Position expected = new Position() { X = 0, Y = 0, Direction = 'W' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands(commands.ToCharArray());

            Assert.AreEqual(expected, rover.Position);
            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void ShouldWrapNorthEdgeForward()
        {
            string commands = "F";
            Position landing = new Position() { X = 0, Y = mars.MaxY - 1, Direction = 'N' };
            Position expected = new Position() { X = 0, Y = 0, Direction = 'N' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands(commands.ToCharArray());

            Assert.AreEqual(expected, rover.Position);
            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void ShouldWrapSouthEdgeForward()
        {
            string commands = "F";
            Position landing = new Position() { X = 0, Y = 0, Direction = 'S' };
            Position expected = new Position() { X = 0, Y = mars.MaxY - 1, Direction = 'S' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands(commands.ToCharArray());

            Assert.AreEqual(expected, rover.Position);
            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void ShouldWrapEastEdgeForward()
        {
            string commands = "F";
            Position landing = new Position() { X = mars.MaxX - 1, Y = 0, Direction = 'E' };
            Position expected = new Position() { X = 0, Y = 0, Direction = 'E' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands(commands.ToCharArray());

            Assert.AreEqual(expected, rover.Position);
            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void ShouldWrapWestEdgeForward()
        {
            string commands = "F";
            Position landing = new Position() { X = 0, Y = 0, Direction = 'W' };
            Position expected = new Position() { X = mars.MaxX - 1, Y = 0, Direction = 'W' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands(commands.ToCharArray());

            Assert.AreEqual(expected, rover.Position);
            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void ShouldWrapSouthEdgeBackward()
        {
            string commands = "B";
            Position landing = new Position() { X = 0, Y = 0, Direction = 'N' };
            Position expected = new Position() { X = 0, Y = mars.MaxY - 1, Direction = 'N' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands(commands.ToCharArray());

            Assert.AreEqual(expected, rover.Position);
            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void ShouldWrapNorthEdgeBackward()
        {
            string commands = "B";
            Position landing = new Position() { X = 0, Y = 0, Direction = 'N' };
            Position expected = new Position() { X = 0, Y = mars.MaxY - 1, Direction = 'N' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands(commands.ToCharArray());

            Assert.AreEqual(expected, rover.Position);
            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void ShouldWrapWestEdgeBackward()
        {
            string commands = "B";
            Position landing = new Position() { X = 0, Y = 0, Direction = 'E' };
            Position expected = new Position() { X = mars.MaxX - 1, Y = 0, Direction = 'E' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands(commands.ToCharArray());

            Assert.AreEqual(expected, rover.Position);
            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void ShouldWrapEastEdgeBackward()
        {
            string commands = "B";
            Position landing = new Position() { X = 0, Y = 0, Direction = 'E' };
            Position expected = new Position() { X = mars.MaxX - 1, Y = 0, Direction = 'E' };

            rover.SetLandingPoint(landing);

            int result = rover.ExecuteCommands(commands.ToCharArray());

            Assert.AreEqual(expected, rover.Position);
            Assert.AreEqual(commands.Length, result);
        }

        [Test]
        public void ShouldDetectForwardObstacle()
        {
            string commands = "F";
            Coordinate obstacle = mars.Obstacles.First();
            Position landing = new Position() { X = obstacle.X, Y = obstacle.Y - 1, Direction = 'N' };
            Position expected = new Position() { X = obstacle.X, Y = obstacle.Y - 1, Direction = 'N' };

            rover.SetLandingPoint(landing);

            int result = 0; ;
            Assert.Throws(typeof(RoverObstacleException), () => { result = rover.ExecuteCommands(commands.ToCharArray()); });
            Assert.AreEqual(expected, rover.Position);
            Assert.AreNotEqual(commands.Length, result);
        }

        [Test]
        public void ShouldDetectBackwardObstacle()
        {
            string commands = "B";
            Coordinate obstacle = mars.Obstacles.First();
            Position landing = new Position() { X = obstacle.X, Y = obstacle.Y + 1, Direction = 'N' };
            Position expected = new Position() { X = obstacle.X, Y = obstacle.Y + 1, Direction = 'N' };

            rover.SetLandingPoint(landing);

            int result = 0; ;
            Assert.Throws(typeof(RoverObstacleException), () => { result = rover.ExecuteCommands(commands.ToCharArray()); });
            Assert.AreEqual(expected, rover.Position);
            Assert.AreNotEqual(commands.Length, result);
        }

        [Test]
        public void ShouldDetectForwardForwardObstacle()
        {
            string commands = "FF";
            Coordinate obstacle = mars.Obstacles.First();
            Position landing = new Position() { X = obstacle.X, Y = obstacle.Y - 2, Direction = 'N' };
            Position expected = new Position() { X = obstacle.X, Y = obstacle.Y - 1, Direction = 'N' };

            rover.SetLandingPoint(landing);

            int result = 0; ;
            Assert.Throws(typeof(RoverObstacleException), () => { result = rover.ExecuteCommands(commands.ToCharArray()); });
            Assert.AreEqual(expected, rover.Position);
            Assert.AreNotEqual(commands.Length, result);
        }

        [Test]
        public void ShouldDetectBackwardBackwardObstacle()
        {
            string commands = "BB";
            Coordinate obstacle = mars.Obstacles.First();
            Position landing = new Position() { X = obstacle.X, Y = obstacle.Y + 2, Direction = 'N' };
            Position expected = new Position() { X = obstacle.X, Y = obstacle.Y + 1, Direction = 'N' };

            rover.SetLandingPoint(landing);

            int result = 0; ;
            Assert.Throws(typeof(RoverObstacleException), () => { result = rover.ExecuteCommands(commands.ToCharArray()); });
            Assert.AreEqual(expected, rover.Position);
            Assert.AreNotEqual(commands.Length, result);
        }
    }
}