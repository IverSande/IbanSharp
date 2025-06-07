namespace IbanSharp.Types;

public class Bban
{
    public string BbanString { get; init; }
    public string? AccountNumber { get; init; }

    public Bban(string bbanString)
    {
        BbanString = bbanString;
    }
    
}