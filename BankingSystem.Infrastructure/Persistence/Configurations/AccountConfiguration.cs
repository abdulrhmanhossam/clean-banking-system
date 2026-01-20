using BankingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infrastructure.Persistence.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Balance)
               .IsRequired()
               .HasPrecision(18, 2);

        builder.Property(x => x.DailyTransferLimit)
               .IsRequired()
               .HasPrecision(18, 2);

        builder.Property(x => x.DailyWithdrawalLimit)
               .IsRequired()
               .HasPrecision(18, 2);

        builder.Property(x => x.Status)
            .HasConversion<int>();

        builder.Property(x => x.CustomerId)
               .IsRequired();

        builder.Property(a => a.RowVersion)
               .IsRowVersion();
    }
}
