namespace PhonebookHomework
{
    public class KeyAlreadyExistsException : Exception
    {
        public KeyAlreadyExistsException()
        {
            
        }

        public KeyAlreadyExistsException(string message)
            :base(message)
        {
            
        }
    }
}


// Look into serialisation