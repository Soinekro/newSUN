using CommonClass.Domain.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CommonClass.API.Filters;

/// <summary>
/// Filtro global que intercepta errores de validación de modelo y devuelve un BaseResponse estandarizado.
/// </summary>
public sealed class ValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.ModelState.IsValid) return;

        var errors = context.ModelState
            .Where(kvp => kvp.Value!.Errors.Count > 0)
            .ToDictionary(
                kvp => kvp.Key.Split('.').Last(),
                kvp => kvp.Value!.Errors
                    .Select(e => string.IsNullOrWhiteSpace(e.ErrorMessage)
                        ? e.Exception?.Message ?? "Valor inválido"
                        : e.ErrorMessage)
                    .ToArray()
            );

        var response = new BaseResponse(
            isSuccess: false,
            message: "Error de validación.",
            errors: errors,
            statusCode: 400
        )
        {
            Data = null
        };

        context.Result = new BadRequestObjectResult(response);
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // no-op
    }
}