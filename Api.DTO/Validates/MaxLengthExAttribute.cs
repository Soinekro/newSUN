using System.ComponentModel.DataAnnotations;

namespace Api.Common.Validates;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class MaxLengthExAttribute : MaxLengthAttribute
{
    public MaxLengthExAttribute(int length) : base(length)
    {
        ErrorMessage = ValidationMessages.MaxLength;
    }

    public override string FormatErrorMessage(string name)
    {
        return base.FormatErrorMessage(name);
    }
}