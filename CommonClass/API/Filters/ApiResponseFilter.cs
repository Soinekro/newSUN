using CommonClass.Domain.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace CommonClass.API.Filters;

/// <summary>
/// Filtro que unifica la conversión de objetos `BaseResponse` a `IActionResult` usando el `StatusCode` dentro del response.
/// Si `StatusCode` es 0, aplica una regla por defecto: success -> 200, failure -> 400.
/// </summary>
public sealed class ApiResponseFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // no-op
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is not ObjectResult objResult) return;

        var value = objResult.Value;
        if (value is null) return;

        var valueType = value.GetType();

        // Detectar si es BaseResponse<T>
        var isBaseResponse = valueType.IsGenericType &&
                             valueType.GetGenericTypeDefinition() == typeof(BaseResponse<>);

        if (!isBaseResponse)
        {
            // También aceptar la clase no genérica BaseResponse si se usa directamente
            isBaseResponse = value is BaseResponse;
        }

        if (!isBaseResponse) return;

        // Obtener propiedades por reflexión
        int statusCode = 0;
        bool isSuccess = false;

        var statusProp = valueType.GetProperty("StatusCode", BindingFlags.Public | BindingFlags.Instance);
        if (statusProp?.GetValue(value) is int scInt)
            statusCode = scInt;

        var successProp = valueType.GetProperty("IsSuccess", BindingFlags.Public | BindingFlags.Instance);
        if (successProp?.GetValue(value) is bool b)
            isSuccess = b;

        // Prioridad: si StatusCode >0 en el response, usarlo. Si no, usar el StatusCode del ObjectResult si existe.
        int finalStatus;
        if (statusCode > 0) finalStatus = statusCode;
        else if (objResult.StatusCode.HasValue) finalStatus = objResult.StatusCode.Value;
        else finalStatus = isSuccess ? 200 : 400;

        context.Result = new ObjectResult(value) { StatusCode = finalStatus };
    }
}