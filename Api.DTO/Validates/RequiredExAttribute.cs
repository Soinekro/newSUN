using System.ComponentModel.DataAnnotations;

namespace Api.Common.Validates;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class RequiredExAttribute : RequiredAttribute
{
    public RequiredExAttribute()
    {
        ErrorMessage = ValidationMessages.Required;
    }

    public override string FormatErrorMessage(string name)
    {
        return base.FormatErrorMessage(name);
    }
}