using IbanSharp.Generators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IbanSharp.Tests.Generators;

[TestClass]
public class IbanGeneratorTest
{
    
    [TestMethod]
    [DataRow("NO", 15)]
    public async Task IbanGenerator_Generate_GeneratesCorrectLength(string countryCode, int length)
    {
        //Arrange
        var ibanGenerator = new IbanGenerator();
        
        //Act
        var iban = ibanGenerator.Generate(countryCode);
        
        //Assert
        Assert.AreEqual(iban.IbanString.Length, length);
    }
}