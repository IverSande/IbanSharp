using IbanSharp.Generators;

namespace IbanSharp.Types;

public class Iban
{
    private IbanChecksumGenerator ChecksumGenerator { get; } = new();
    public string IbanString { get; init; }
    public string CountryCode { get; init; }
    public Bban Bban { get; init; }
    
    public string BankCode => Bban.BankCode ?? string.Empty;
    public string BranchCode => Bban.BranchCode ?? string.Empty;

    public Iban(string ibanAsString) : this(new Bban(ibanAsString[4..]), ibanAsString[..1]) {}

    public Iban(Bban bban, string countryCode)
    {
        IbanString = countryCode + ChecksumGenerator.GenerateIbanChecksum(countryCode, bban.BbanString) + bban.BbanString;
        CountryCode = countryCode;
        Bban = bban;

    }
    
}