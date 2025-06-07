using IbanSharp.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IbanSharp.Tests.Generators;

[TestClass]
public class IbanChecksumGeneratorTest
{
    [TestMethod]
    [DataRow("NO", "86011117947", "93")]
    public async Task IbanChecksumGenerator_GenerateIbanChecksum_GeneratesCorrectIban(string countryCode, string bban, string expectedIban)
    {
        //Arrange
        var ibanChecksumGenerator = new IbanChecksumGenerator();
        
        //Act
        var iban = ibanChecksumGenerator.GenerateIbanChecksum(countryCode, bban);
        
        //Assert
        Assert.AreEqual(iban, expectedIban);
    }
    
}