using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using BankingSystem.Infrastructure.Persistence;

namespace BankingSystem.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BankingDbContext _context;

    public UserRepository(BankingDbContext context)
    {
        _context = context;
    }

    public User GetByEmail(string email)
        => _context.Users.Single(u => u.Email == email);
}
