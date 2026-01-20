using BankingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infrastructure.Persistence.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Amount)
               .HasPrecision(18, 2);

        builder.Property(x => x.Type)
               .HasConversion<int>()
               .IsRequired();

        builder.Property(x => x.Status)
               .HasConversion<int>()
               .IsRequired();

        builder.Property(x => x.ReversedTransactionId);

        builder.Property(x => x.CreatedAt)
               .IsRequired();

        builder.Property(x => x.IsDeleted)
                .IsRequired();

        builder.Property(x => x.DeletedAt);

        builder.Property(x => x.CompletedAt);

        // Global Query Filter
        builder.HasQueryFilter(t => !t.IsDeleted);
    }
}
