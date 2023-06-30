namespace HMSUserAPI.Exceptions
{
    public class CustomException
    {
    }

    public class ContextException : Exception
    {
        public ContextException() : base("Context not found") { }
        public ContextException(string message) : base(message) { }
        
    
    }

    public class UserException : Exception
    {
        public UserException() : base("User Exception raised") { }
        public UserException(string message) : base(message) { }


    }
}
