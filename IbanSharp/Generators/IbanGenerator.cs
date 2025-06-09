using IbanSharp.Generators.Countries;
using IbanSharp.Types;

namespace IbanSharp.Generators;

internal class IbanGenerator
{
    internal Iban Generate(string countryCode) => countryCode switch
    {
        "NO" => new Iban(new Norway().GenerateBban(), countryCode),
        _ => new Iban(new Norway().GenerateBban(), countryCode),
    };
}