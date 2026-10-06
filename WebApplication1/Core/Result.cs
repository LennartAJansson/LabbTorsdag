namespace WebApplication1.Core;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Lightweight Result pattern implementation for endpoints and application logic.
/// Use Result.Success / Result.Failure for non-value results and Result&lt;T&gt; for value results.
/// </summary>
public sealed class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public string? Error { get; }

    private Result(bool isSuccess, string? error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new Result(true, null);

    public static Result Failure(string error)
    {
        if (string.IsNullOrWhiteSpace(error))
            throw new ArgumentException("Failure result must contain a non-empty error message.", nameof(error));

        return new Result(false, error);
    }

    public static Result<T> Success<T>(T value) => Result<T>.Success(value);

    public static Result<T> Failure<T>(string error) => Result<T>.Failure(error);

    /// <summary>
    /// Combines multiple results. If any is failure, returns the first failure (or a combined message).
    /// Otherwise returns Success.
    /// </summary>
    public static Result Combine(params Result[] results)
    {
        if (results == null) throw new ArgumentNullException(nameof(results));

        var failures = results.Where(r => r.IsFailure).ToArray();
        if (!failures.Any()) return Success();

        if (failures.Length == 1) return Failure(failures[0].Error!);

        var combined = string.Join("; ", failures.Select(f => f.Error));
        return Failure(combined);
    }
}

public sealed class Result<T>
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    private readonly T? _value;
    public T Value
    {
        get
        {
            if (!IsSuccess) throw new InvalidOperationException("Cannot access Value of a failed Result.");
            // Value may legitimately be null for reference types; caller should know.
            return _value!;
        }
    }

    public string? Error { get; }

    private Result(bool isSuccess, T? value, string? error)
    {
        IsSuccess = isSuccess;
        _value = value;
        Error = error;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(true, value, null);
    }

    public static Result<T> Failure(string error)
    {
        if (string.IsNullOrWhiteSpace(error))
            throw new ArgumentException("Failure result must contain a non-empty error message.", nameof(error));

        return new Result<T>(false, default, error);
    }

    /// <summary>
    /// Maps a successful result's value to another value. If this is a failure, the failure is propagated.
    /// </summary>
    public Result<TResult> Map<TResult>(Func<T, TResult> mapper)
    {
        if (mapper == null) throw new ArgumentNullException(nameof(mapper));
        return IsSuccess ? Result<TResult>.Success(mapper(Value)) : Result<TResult>.Failure(Error!);
    }

    /// <summary>
    /// Binds (flatMaps) a successful result into another Result-returning function.
    /// </summary>
    public Result<TResult> Bind<TResult>(Func<T, Result<TResult>> binder)
    {
        if (binder == null) throw new ArgumentNullException(nameof(binder));
        return IsSuccess ? binder(Value) : Result<TResult>.Failure(Error!);
    }

    /// <summary>
    /// Combines multiple Result&lt;T&gt; into Result (without values). Failure if any fail.
    /// </summary>
    public static Result Combine(params Result<T>[] results)
    {
        if (results == null) throw new ArgumentNullException(nameof(results));

        var failures = results.Where(r => r.IsFailure).ToArray();
        if (!failures.Any()) return Result.Success();

        if (failures.Length == 1) return Result.Failure(failures[0].Error!);

        var combined = string.Join("; ", failures.Select(f => f.Error));
        return Result.Failure(combined);
    }
}
