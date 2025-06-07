using IbanSharp.Generators;
using IbanSharp.Types;

namespace IbanSharp;

public class IbanSharp
{
    private readonly IbanGenerator _ibanGenerator;

    public IbanSharp()
    {
        _ibanGenerator = new IbanGenerator();
    }
    
    public Iban GenerateRandomIban(string countryCode = "NO")
    {
        return _ibanGenerator.Generate(countryCode);
    }
}