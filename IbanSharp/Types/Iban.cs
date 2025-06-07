using IbanSharp.Generators;

namespace IbanSharp.Types;

public class Iban
{
    private IbanChecksumGenerator ChecksumGenerator { get; set; } = new();
    public string IbanString { get; init; }
    public string CountryCode { get; init; }
    public Bban Bban { get; init; }
    public string? BankCode { get; init; }
    public string? BranchCode { get; init; }

    public Iban(string ibanAsString)
    {
        
        IbanString = ibanAsString;
    }

    public Iban(Bban bban, string countryCode)
    {
        IbanString = countryCode + ChecksumGenerator.GenerateIbanChecksum(countryCode, bban.BbanString) + bban.BbanString;
        CountryCode = countryCode;
        Bban = bban;

    }
    
}