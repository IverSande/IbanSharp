using IbanSharp.Types;

namespace IbanSharp.Generators.Countries;

internal class Norway
{
    private readonly Random _random = new();
    private readonly int[] _numbers = Enumerable.Range(0, 9).Select(c => c).ToArray();
    private List<int> Numeric(int length) => Enumerable.Range(0, length).Select(_ => _numbers[_random.Next(0, 9)]).ToList();
    
    //Will not generate a legal bank code, but a bban with legal bban checksums for
    //norway and a bankcode that is probably not corresponding to a real bank
    internal Bban GenerateBban()
    {
        int[] weights = [5, 4, 3, 2, 7, 6, 5, 4, 3, 2];
        var accountNumber = Numeric(10);

        var checkSum = NoBbanChecksum(accountNumber);
        if(checkSum is 11 or 10)
        {
            accountNumber[0] += 1;
            checkSum = NoBbanChecksum(accountNumber);
        }
        accountNumber.Add(checkSum);

        var bbanString = string.Join("", accountNumber);
        
        return new Bban(bbanString, bbanString[..3]);


        int NoBbanChecksum(List<int> an)
        {
            var sum = an.Zip(weights).Aggregate(0, (i, tuple) => i + tuple.First * tuple.Second);
            return 11 - sum % 11;
        }
    }

}