using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.AggregateModel.BuyerAggregate;

namespace Ordering.Infrastructure.EntityConfigrations
{
    internal class BuyerEntityTypeConfigration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.FirstName)
                .HasMaxLength(25)
                .IsRequired();
        }
    }
}
