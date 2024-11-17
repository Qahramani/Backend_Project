namespace Pustok.BLL.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message = "nor found") : base(message)
    {

    }
}
