using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverLibrary
{
    [Serializable]
    public class RoverException : Exception
    {
        public RoverException(string message) : base(message)
        {
        }

        public RoverException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public RoverException()
        {
        }

        protected RoverException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class RoverObstacleException : RoverException
    {
        public RoverObstacleException(string message) : base(message)
        {
        }

        public RoverObstacleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public RoverObstacleException()
        {
        }

        protected RoverObstacleException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class RoverUnknownCommandException : RoverException
    {
        public RoverUnknownCommandException(string message) : base(message)
        {
        }

        public RoverUnknownCommandException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public RoverUnknownCommandException()
        {
        }

        protected RoverUnknownCommandException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class RoverOutOfBoundariesException : RoverException
    {
        public RoverOutOfBoundariesException(string message) : base(message)
        {
        }

        public RoverOutOfBoundariesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public RoverOutOfBoundariesException()
        {
        }

        protected RoverOutOfBoundariesException(System.Runtime.Serialization.SerializationInfo serializationInfo, System.Runtime.Serialization.StreamingContext streamingContext)
        {
            throw new NotImplementedException();
        }
    }
}
