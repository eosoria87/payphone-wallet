namespace Wallet.Domain.Entities;

public class BaseEntity
{
    public int Id { get; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }

    protected BaseEntity()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow; 
    }
    
    protected BaseEntity(int id)
    {
        Id = id;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow; 
    }
    
    protected BaseEntity(int id, DateTime createdAt, DateTime updatedAt)
    {
        Id = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt; 
    }

    public void SetUpdatedAt()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}