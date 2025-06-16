namespace IbanSharp.Validators.Bban.Countries;

public class NO : IBbanValidator 
{
    
    private int[] weights = [5, 4, 3, 2, 7, 6, 5, 4, 3, 2];
    public bool ValidateBban(string bban)
    {
        if (bban.Length != 11)
            return false;
        
        var bbanList = bban.Select(c => int.Parse(c.ToString())).ToList();
        var checksum = NoBbanChecksum(bbanList[..9]);
        
        return checksum == bbanList[10];
    }
    
    private int NoBbanChecksum(List<int> an)
    {
        var sum = an.Zip(weights).Aggregate(0, (i, tuple) => i + tuple.First * tuple.Second);
        return 11 - sum % 11;
    }
}