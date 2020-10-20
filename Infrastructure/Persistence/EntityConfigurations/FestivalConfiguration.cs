using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityConfigurations
{
    public class FestivalConfiguration : IEntityTypeConfiguration<Festival>
    {
        public void Configure(EntityTypeBuilder<Festival> builder)
        {
            builder.Property(f => f.Title)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(f => f.Description)
                .HasMaxLength(1000);
            
            builder.Property(f => f.StartDate)
                .IsRequired();
            
            builder.Property(f => f.EndDate)
                .IsRequired();
            
            builder.HasOne(f => f.Address)
                .WithOne();
            
            builder.Property(a => a.RowVersion)
                .IsRowVersion();
        }
    }
}