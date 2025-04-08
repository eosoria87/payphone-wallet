namespace Wallet.Application.Wallet.Dto;

public class WalletResponse
{
    public int Id { get; set; }
    public string DocumentId { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }

    public WalletResponse(int id,  string documentId, string name, decimal balance)
    {
        Id = id;
        DocumentId = documentId;
        Name = name;
        Balance = balance;
    }
    
    
    public static WalletResponse FromEntity(Domain.Entities.Wallet entity)
    {
        return new WalletResponse(entity.Id, entity.DocumentId, entity.Name, entity.Balance);
    }
}