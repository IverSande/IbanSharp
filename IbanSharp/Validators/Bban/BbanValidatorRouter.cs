using System.Reflection;

namespace IbanSharp.Validators.Bban;

internal class BbanValidatorRouter
{

    internal bool ValidateBban(string bban, string countryCode)
    {
        var type = Assembly.GetExecutingAssembly()
                                   .GetTypes()
                                   .FirstOrDefault(t => t.Name == countryCode && typeof(IBbanValidator).IsAssignableFrom(t));
        if (type == null)
            return false;

        var bbanValidator = (IBbanValidator)Activator.CreateInstance(type!)!;
        
        return bbanValidator.ValidateBban(bban);
    }
}