using System.ComponentModel.DataAnnotations;

namespace Api.Common.Validates;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class MinLengthExAttribute : MinLengthAttribute
{
    public MinLengthExAttribute(int length) : base(length)
    {
        ErrorMessage = ValidationMessages.MinLength;
    }

    public override string FormatErrorMessage(string name)
    {
        return base.FormatErrorMessage(name);
    }
}