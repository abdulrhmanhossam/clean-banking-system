using BankingSystem.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankingSystem.Infrastructure.BackgroundJobs;

public class DailyLimitResetJob : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public DailyLimitResetJob(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromDays(1), stoppingToken);

            using var scope = _scopeFactory.CreateScope();
            var service = scope.ServiceProvider
                .GetRequiredService<DailyLimitResetService>();

            service.Reset();
        }
    }
}
