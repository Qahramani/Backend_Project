namespace Pustok.BLL.Exceptions;

public class InvalidInputException : Exception
{
    public InvalidInputException(string message = "invalid input") : base(message)
    {
        
    }
}
