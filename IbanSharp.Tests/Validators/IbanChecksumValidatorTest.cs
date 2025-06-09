using IbanSharp.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IbanSharp.Tests.Validators;

[TestClass]
public class IbanChecksumValidatorTest
{

    [TestMethod]
    [DataRow("NO9386011117947", true)]
    [DataRow("NO9486011117947", false)]
    public async Task IbanChecksumValidator_IsValidIban_ValidatesIban(string iban, bool expectedResult)
    {

        //Arrange
        var ibanValidator = new IbanChecksumValidator();

        //Act
        var result = ibanValidator.IsValidIban(iban);
        
        //Assert
        Assert.AreEqual(expectedResult, result);

    }
    
}