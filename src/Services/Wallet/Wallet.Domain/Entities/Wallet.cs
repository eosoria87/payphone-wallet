namespace Wallet.Domain.Entities;

public class Wallet : BaseEntity
{
    public string DocumentId { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    
    public Wallet()
    {
    }
    public Wallet(string documentId, string name, decimal balance) : this()
    {
        DocumentId = documentId;
        Name = name;
        Balance = balance;
    }
}