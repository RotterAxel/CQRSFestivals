using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(a => a.Number)
                .IsRequired()
                .HasMaxLength(15);
            
            builder.Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(15);
            
            builder.Property(a => a.State)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(a => a.RowVersion)
                .IsRowVersion();
        }
    }
}