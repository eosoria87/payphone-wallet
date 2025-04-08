namespace Wallet.Domain.Models;

public class ErrorResponse
{
    public int Code { get; init; }
    public string Message { get; set; } = string.Empty;
        
    private readonly string _details = string.Empty;
    public string Details
    {
        get => Code is 100 or 101 or 102 or 442 ? _details : string.Empty;
        init => _details = value;
    }
        
    public string GetDetails()
    {
        return _details;
    }
}