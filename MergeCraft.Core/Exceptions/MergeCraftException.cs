using System;

namespace MergeCraft.Core.Exceptions
{
    public class MergeCraftException : Exception
    {
        public MergeCraftException(string message)
            : base(message)
        {
        }

        public MergeCraftException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
