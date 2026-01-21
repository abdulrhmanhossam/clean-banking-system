using BankingSystem.Domain.Entities;

namespace BankingSystem.Application.Interfaces;

public interface IJwtTokenGenerator
{
    string Generate(User user);
}