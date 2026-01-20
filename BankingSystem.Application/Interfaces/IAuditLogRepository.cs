using BankingSystem.Domain.Entities;

namespace BankingSystem.Application.Interfaces;

public interface IAuditLogRepository
{
    void Add(AuditLog log);
}