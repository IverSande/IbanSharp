using IbanSharp.Generators.Countries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IbanSharp.Tests.Generators.Countries;

[TestClass]
public class NorwayTest
{

    [TestMethod]
    public async Task NorwayGenerator_GenerateBban_GeneratesExpectedLength()
    {
        //Arrange 
        var bbanGenerator = new Norway();

        //Act
        var bban = bbanGenerator.GenerateBban();
        
        //Assert
        Assert.HasCount(11, bban.BbanString);
    }
    
}