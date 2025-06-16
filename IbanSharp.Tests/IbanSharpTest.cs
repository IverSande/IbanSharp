using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IbanSharp.Tests;

[TestClass]
public class IbanSharpTest
{
    private readonly IbanSharp _ibanSharp = new IbanSharp();


    [TestMethod]
    [DataRow("NO9386011117947", true)]
    [DataRow("NO9486011117947", false)]
    public async Task IbanSharp_ValidateIban_ValidatesCorrect(string iban, bool expectedResult)
    {
        //Act
        var result = _ibanSharp.ValidateIban(iban);

        //Assert
        Assert.AreEqual(expectedResult, result);
    }
    
    [TestMethod]
    [DataRow("NO9386011117947", "NO", true)]
    [DataRow("NO9486011117947", "NO", false)]
    public async Task IbanSharp_ValidateIbanAndBban_ValidatesCorrect(string iban, string countryCode, bool expectedResult)
    {
        //Act
        var result = _ibanSharp.ValidateIbanAndBban(iban, countryCode);

        //Assert
        Assert.AreEqual(expectedResult, result);
    }
    
}