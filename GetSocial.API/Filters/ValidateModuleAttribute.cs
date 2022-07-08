using GetSocial.API.Contracts.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GetSocial.API.Filters;

public class ValidateModuleAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var apiError = new ErrorResponse
            {
                StatusCode = 400,
                StatusPhrase = "Bad Request",
                Timestamp = DateTime.UtcNow
            };
            var errors = context.ModelState.AsEnumerable();
            
            foreach (var error in errors)
            {
                apiError.Errors.Add(error.Value.ToString());
            }
            context.Result = new JsonResult(apiError) { StatusCode = 400 };
        }
    }
}