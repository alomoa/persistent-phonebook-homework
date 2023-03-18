using System.Runtime.Serialization;

namespace PhonebookHomework
{
    [Serializable]
    public class IncorrectLengthNumberException : Exception
    {
        public IncorrectLengthNumberException()
        {
        }

        public IncorrectLengthNumberException(string? message) : base(message)
        {
        }

        public IncorrectLengthNumberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected IncorrectLengthNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}


// Look into serialisation