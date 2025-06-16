namespace IbanSharp.Types;

public class Bban
{
    public string BbanString { get; init; }
    public string? AccountNumber { get; init; }
    public string? BankCode { get; init; }
    public string? BranchCode { get; init; }

    public Bban(string bbanString)
    {
        BbanString = bbanString;
    }

    public Bban(string bbanString, string? accountNumber, string? bankCode, string? branchCode)
    {
        BbanString = bbanString;
        AccountNumber = accountNumber;
        BranchCode = branchCode;
        BankCode = bankCode;
    }
    
    public Bban(string bbanString, string? bankCode)
    {
        BbanString = bbanString;
        BankCode = bankCode;
    }
    
}