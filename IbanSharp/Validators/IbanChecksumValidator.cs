using System.Numerics;
using System.Text;

namespace IbanSharp.Validators;

internal class IbanChecksumValidator
{
    internal bool IsValidIban(string iban)
    {
        if (string.IsNullOrWhiteSpace(iban))
            return false;

        iban = iban.Replace(" ", "").ToUpper();

        if (iban.Length is < 15 or > 34)
            return false;

        // Move the first four characters to the end
        string rearranged = iban.Substring(4) + iban.Substring(0, 4);

        // Convert letters to numbers (A=10, B=11, ..., Z=35)
        StringBuilder numericIban = new();
        foreach (char ch in rearranged)
        {
            if (char.IsLetter(ch))
                numericIban.Append((ch - 'A' + 10).ToString());
            else if (char.IsDigit(ch))
                numericIban.Append(ch);
            else
                return false; // Invalid character
        }

        // Use BigInteger to handle large numbers
        var ibanNumber = BigInteger.Parse(numericIban.ToString());
        return ibanNumber % 97 == 1;
    }
    
}