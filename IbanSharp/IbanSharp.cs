using IbanSharp.Generators;
using IbanSharp.Types;
using IbanSharp.Validators;
using IbanSharp.Validators.Bban;

namespace IbanSharp;

public class IbanSharp
{
    private readonly IbanGenerator _ibanGenerator;
    private readonly IbanChecksumValidator _ibanChecksumValidator;
    private readonly BbanValidatorRouter _bbanValidatorRouter;

    public IbanSharp()
    {
        _ibanGenerator = new IbanGenerator();
        _ibanChecksumValidator = new IbanChecksumValidator();
        _bbanValidatorRouter = new BbanValidatorRouter();
    }
    
    /// <summary>
    /// Generates a random Iban based on the country code passed.
    /// If it is implemented the bban will be mostly valid based on local rules, if not it will be a random bban that only is correct by length.
    /// The default random Iban will be a norwegian Iban (Country code = NO)
    /// </summary>
    /// <param name="countryCode"></param>
    /// <returns></returns>
    public Iban GenerateRandomIban(string countryCode = "NO")
    {
        return _ibanGenerator.Generate(countryCode);
    }

    /// <summary>
    /// Validates whether an iban has a valid checksum.
    /// For validating the iban and the bban part use ValidateIbanAndBban 
    /// </summary>
    /// <param name="iban">An iban as a string</param>
    /// <returns>true if valid, false if not</returns>
    public bool ValidateIban(string iban)
    {
        return _ibanChecksumValidator.HasValidIbanChecksum(iban);
    }

    /// <summary>
    /// Validates the iban and the bban within if the bban validator for the chosen country code is implemented
    /// </summary>
    /// <param name="iban"></param>
    /// <param name="countryCode"></param>
    /// <returns>true if valid, false if not</returns>
    public bool ValidateIbanAndBban(string iban, string countryCode)
    {
        var validIbanChecksum = _ibanChecksumValidator.HasValidIbanChecksum(iban);
        var validBban = _bbanValidatorRouter.ValidateBban(iban[4..], countryCode);
        
        return validIbanChecksum && validBban;
    }
}