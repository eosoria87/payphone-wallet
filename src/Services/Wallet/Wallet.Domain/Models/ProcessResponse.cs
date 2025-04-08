namespace Wallet.Domain.Models;

public class ProcessResponse
{
    public bool IsSuccess { get; set; }
    public ErrorResponse ErrorResponse { get; init; } = new();
        
    public static ProcessResponse<T> Success<T>(T value)
    {
        return new ProcessResponse<T>
        {
            IsSuccess = true,
            Value = value,
            ErrorResponse = new ErrorResponse()
        };
    }
}
    
public class ProcessResponse<T> : ProcessResponse
{
    public T Value { get; set; }

    public static ProcessResponse<T> Error(string message)
    {
        var processErrorResponse = new ErrorResponse
        {
            Message = message,
            Details = message
        };
                
        return new ProcessResponse<T>
        {
            IsSuccess = false,
            ErrorResponse = processErrorResponse
        };
    }
        
    public static ProcessResponse<T> Error(int code, string message)
    {
        var processErrorResponse = new ErrorResponse
        {
            Code = code,
            Message = message,
            Details = message
        };
                
        return new ProcessResponse<T>
        {
            IsSuccess = false,
            ErrorResponse = processErrorResponse
        };
    }
        
    public static ProcessResponse<T> Error(ProcessResponse processResponse)
    {
        return new ProcessResponse<T>
        {
            IsSuccess = false,
            ErrorResponse = processResponse.ErrorResponse
        };
    }
        
    public static ProcessResponse<T> Error(Exception exception)
    {
        var processErrorResponse = new ErrorResponse
        {
            Code = exception.GetHashCode(),
            Message = exception.Message,
        };
            
        return new ProcessResponse<T>
        {
            IsSuccess = false,
            ErrorResponse = processErrorResponse
        };
    }
        
    public static ProcessResponse<T> Error(string message, Exception exception)
    {
        var processErrorResponse = new ErrorResponse
        {
            Code = exception.GetHashCode(),
            Message = message,
        };
            
        return new ProcessResponse<T>
        {
            IsSuccess = false,
            ErrorResponse = processErrorResponse
        };
    }
        
    public static ProcessResponse<T> Error(int code, string message, Exception exception)
    {
        var processErrorResponse = new ErrorResponse
        {
            Code = code,
            Message = message,
        };
            
        return new ProcessResponse<T>
        {
            IsSuccess = false,
            ErrorResponse = processErrorResponse
        };
    }
}