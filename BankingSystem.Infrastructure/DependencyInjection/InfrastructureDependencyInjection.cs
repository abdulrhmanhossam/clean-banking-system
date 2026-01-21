using BankingSystem.Application.Interfaces;
using BankingSystem.Application.Services;
using BankingSystem.Infrastructure.BackgroundJobs;
using BankingSystem.Infrastructure.Persistence;
using BankingSystem.Infrastructure.Repositories;
using BankingSystem.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem.Infrastructure.DependencyInjection;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<BankingDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"))
            );
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IAuditLogRepository, AuditLogRepository>();
        services.AddScoped<ITransactionReadRepository, TransactionReadRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        services.AddHostedService<DailyLimitResetJob>();

        return services;
    }
}
