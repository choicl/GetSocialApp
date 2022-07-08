using GetSocial.API.Contracts.Common;
using GetSocial.Application.Enums;
using GetSocial.Application.ResultsModel;
using GetSocial.Domain.Aggregates.UserProfileAggregate;
using Microsoft.AspNetCore.Mvc;

namespace GetSocial.API.Controllers.V1;

public class BaseController : ControllerBase
{
    protected IActionResult HandleErrorResponse(List<Error> errors)
    {
        if (errors.Any(e => e.Code == ErrorCode.NotFound))
        {
            var error = errors.First(e => e.Code == ErrorCode.NotFound);
            var apiError = new ErrorResponse
            {
                StatusCode = 404,
                StatusPhrase = "Not Found",
                Timestamp = DateTime.UtcNow
            };
            apiError.Errors.Add(error.Message);
            return NotFound(apiError);
        }
        if (errors.Any(e => e.Code == ErrorCode.ServerError))
        {
            var error = errors.First(e => e.Code == ErrorCode.ServerError);
            var apiError = new ErrorResponse
            {
                StatusCode = 500,
                StatusPhrase = "Internal Server Error",
                Timestamp = DateTime.UtcNow
            };
            apiError.Errors.Add(error.Message);
            return BadRequest(apiError);
        }

        return Ok();
    }
}