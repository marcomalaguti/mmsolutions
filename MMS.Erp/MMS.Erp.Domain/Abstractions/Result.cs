namespace MMS.Erp.Domain.Abstractions;

using System;

public class Result
{
    public Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
    //public T? Value { get; }
    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);
}


public class Result<T>
{
    public Result(T value)
    {
        IsSuccess = true;
        Error = Error.None;
        Value = value;
    }
    public Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
    public T? Value { get; }
    public static Result<T> Success() => new(true, Error.None);
    public static Result<T> Success(T value) => new(value);
    public static Result<T> Failure(Error error) => new(false, error);
}
