namespace BankingSystem.Domain.Entities;

public class AuditLog
{
    public Guid Id { get; private set; }
    public string Action { get; private set; }
    public string Entity { get; private set; }
    public Guid EntityId { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public string? Details { get; private set; }

    private AuditLog() { }

    public AuditLog(
        string action,
        string entity,
        Guid entityId,
        Guid userId,
        string? details = null)
    {
        Id = Guid.NewGuid();
        Action = action;
        Entity = entity;
        EntityId = entityId;
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
        Details = details;
    }
}