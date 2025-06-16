namespace IbanSharp.Validators.Bban;

internal interface IBbanValidator
{
    internal bool ValidateBban(string bban);
}