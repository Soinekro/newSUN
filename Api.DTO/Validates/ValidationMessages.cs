namespace Api.Common.Validates;

public static class ValidationMessages
{
    // {0} = nombre del campo (DisplayName)
    public const string Required = "El campo {0} es obligatorio.";
    public const string Email = "El campo {0} no es un correo electrónico válido.";
    public const string MaxLength = "El campo {0} no debe superar los {1} caracteres.";
    public const string MinLength = "El campo {0} debe tener al menos {1} caracteres.";
}