namespace Wallet.Domain.Entities;

public class BaseEntity
{
    public int Id { get; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; set; }

    protected BaseEntity()
    {
        //Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow; 
    }
    
    protected BaseEntity(Guid id)
    {
        //Id = id;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow; 
    }
    
    protected BaseEntity(Guid id, DateTime createdAt, DateTime updatedAt)
    {
        //qId = id;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt; 
    }

    public void SetUpdatedAt()
    {
        UpdatedAt = DateTime.UtcNow;
    }
}