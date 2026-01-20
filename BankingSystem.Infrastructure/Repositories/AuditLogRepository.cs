using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using BankingSystem.Infrastructure.Persistence;

namespace BankingSystem.Infrastructure.Repositories;

public class AuditLogRepository : IAuditLogRepository
{
    private readonly BankingDbContext _context;
    public AuditLogRepository(BankingDbContext context)
    {
        _context = context;
    }
    public void Add(AuditLog log)
    {
        _context.AuditLogs.Add(log);
    }
}