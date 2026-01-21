using BankingSystem.Domain.Entities;

namespace BankingSystem.Application.Interfaces;

public interface IUserRepository
{
    User GetByEmail(string email);

}