using IbanSharp.Generators.Countries;
using IbanSharp.Types;

namespace IbanSharp.Generators;

internal class IbanGenerator
{
    internal Iban Generate(string countryCode) => countryCode switch
    {
        "NO" => new Iban(Norway.GenerateBban(), countryCode),
        _ => new Iban(Norway.GenerateBban(), countryCode)
    };
}