using System.Numerics;
using System.Text;

namespace IbanSharp.Generators;

internal class IbanChecksumGenerator
{
    internal string GenerateIbanChecksum(string countryCode, string bban)
    {
        // Step 1: Move country code and checksum to the end
        string rearranged = bban + countryCode + "00";

        // Step 2: Replace letters with numbers (A=10, B=11, ..., Z=35)
        StringBuilder numericIban = new();
        foreach (char ch in rearranged)
        {
            if (char.IsLetter(ch))
                numericIban.Append((ch - 'A' + 10).ToString());
            else
                numericIban.Append(ch);
        }

        // Step 3: Calculate the remainder of the numeric IBAN mod 97
        var ibanNumber = BigInteger.Parse(numericIban.ToString());
        int checksum = 98 - (int)(ibanNumber % 97);

        // Step 4: Format checksum as two digits
        return checksum.ToString("D2");
    }
}