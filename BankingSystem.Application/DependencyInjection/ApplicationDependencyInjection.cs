using BankingSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem.Application.DependencyInjection;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Register application services here
        services.AddScoped<TransactionReversalService>();
        services.AddScoped<TransactionAdminService>();
        services.AddScoped<AccountStatementService>();
        services.AddScoped<DailyLimitResetService>();
        services.AddScoped<AccountService>();
        services.AddScoped<CustomerService>();
        services.AddScoped<TransferService>();

        return services;
    }
}
