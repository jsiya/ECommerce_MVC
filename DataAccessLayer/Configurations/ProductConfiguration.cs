using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Name)
            .HasColumnType("nvarchar(50)")
            .IsRequired();
        builder.Property(p => p.Description)
            .HasColumnType("nvarchar(500)");
        builder.Property(p => p.ImageUrl)
            .HasColumnType("nvarchar(500)");
    }
}