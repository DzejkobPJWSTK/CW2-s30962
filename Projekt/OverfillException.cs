namespace Projekt;

public class OverfillException : Exception
{
    public OverfillException(string message)
    {
        Console.WriteLine(message);
    }
}