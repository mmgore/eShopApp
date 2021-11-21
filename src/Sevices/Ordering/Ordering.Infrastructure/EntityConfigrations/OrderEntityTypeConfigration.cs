using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.AggregateModel.BuyerAggregate;
using Ordering.Domain.AggregateModel.OrderAggregate;

namespace Ordering.Infrastructure.EntityConfigrations
{
    public class OrderEntityTypeConfigration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Username)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(b => b.Country)
                .HasMaxLength(25)
                .IsRequired();

            builder.HasOne<Buyer>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("BuyerId");
        }
    }
}
