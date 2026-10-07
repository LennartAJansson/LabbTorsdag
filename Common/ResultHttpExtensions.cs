using System;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Common;

/// <summary>
/// Extension helpers to convert Result / Result<T> into HTTP results for Minimal APIs (IResult)
/// and MVC controllers (IActionResult).
/// Default failure mapping returns 400 Bad Request with a simple error payload.
/// Supply a custom failure mapper to return NotFound, Conflict, Problem, etc.
/// </summary>
public static class ResultHttpExtensions
{
    // Minimal API (IResult) mappings
    public static IResult ToMinimalApiResult(this Result result, Func<string, IResult>? failureMapper = null)
    {
        if (result == null) throw new ArgumentNullException(nameof(result));

        if (result.IsSuccess) return Results.NoContent();

        failureMapper ??= err => Results.BadRequest(new { error = err });
        return failureMapper(result.Error!);
    }

    public static IResult ToMinimalApiResult<T>(this Result<T> result, Func<string, IResult>? failureMapper = null)
    {
        if (result == null) throw new ArgumentNullException(nameof(result));

        if (result.IsSuccess) return Results.Ok(result.Value);

        failureMapper ??= err => Results.BadRequest(new { error = err });
        return failureMapper(result.Error!);
    }

    // MVC Controller mappings (IActionResult)
    public static IActionResult ToActionResult(this Result result, Func<string, IActionResult>? failureMapper = null)
    {
        if (result == null) throw new ArgumentNullException(nameof(result));

        if (result.IsSuccess) return new NoContentResult();

        failureMapper ??= err => new BadRequestObjectResult(new { error = err });
        return failureMapper(result.Error!);
    }

    public static IActionResult ToActionResult<T>(this Result<T> result, Func<string, IActionResult>? failureMapper = null)
    {
        if (result == null) throw new ArgumentNullException(nameof(result));

        if (result.IsSuccess) return new OkObjectResult(result.Value);

        failureMapper ??= err => new BadRequestObjectResult(new { error = err });
        return failureMapper(result.Error!);
    }
}
