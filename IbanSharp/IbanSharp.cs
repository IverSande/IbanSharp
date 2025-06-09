using IbanSharp.Generators;
using IbanSharp.Types;
using IbanSharp.Validators;

namespace IbanSharp;

public class IbanSharp
{
    private readonly IbanGenerator _ibanGenerator;
    private readonly IbanChecksumValidator _ibanChecksumValidator;

    public IbanSharp()
    {
        _ibanGenerator = new IbanGenerator();
        _ibanChecksumValidator = new IbanChecksumValidator();
    }
    
    public Iban GenerateRandomIban(string countryCode = "NO")
    {
        return _ibanGenerator.Generate(countryCode);
    }

    public bool ValidateIban(string iban)
    {
        return _ibanChecksumValidator.IsValidIban(iban);
    }
}