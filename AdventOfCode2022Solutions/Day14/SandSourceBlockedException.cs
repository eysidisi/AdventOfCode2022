using System.Runtime.Serialization;

namespace AdventOfCode2022Tests.Day14
{
    [Serializable]
    internal class SandSourceBlockedException : Exception
    {
        public SandSourceBlockedException()
        {
        }

        public SandSourceBlockedException(string? message) : base(message)
        {
        }

        public SandSourceBlockedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected SandSourceBlockedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
