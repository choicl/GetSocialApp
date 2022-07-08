using GetSocial.API.Contracts.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GetSocial.API.Filters;

public class AppExceptionHandler : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var apiError = new ErrorResponse
        {
            StatusCode = 500,
            StatusPhrase = "Internal Server Error",
            Timestamp = DateTime.UtcNow
        };
        apiError.Errors.Add(context.Exception.Message);

        context.Result = new JsonResult(apiError) { StatusCode = 500 };
    }
}