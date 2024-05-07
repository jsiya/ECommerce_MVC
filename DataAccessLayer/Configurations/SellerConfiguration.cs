using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations;

public class SellerConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        
        builder.Property(c => c.Username)
            .HasColumnType("nvarchar(50)")
            .IsRequired();
        builder.Property(c => c.FirstName)
            .HasColumnType("nvarchar(50)")
            .IsRequired();
        builder.Property(c => c.LastName)
            .HasColumnType("nvarchar(50)")
            .IsRequired();
        builder.Property(c => c.Password)
            .HasColumnType("nvarchar(50)")
            .IsRequired();
        builder.Property(c => c.Address)
            .HasColumnType("nvarchar(100)");
        builder.Property(c => c.UserRole)
            .HasDefaultValue("Seller");
        //relations
        builder.HasMany(s => s.Products)
            .WithOne(p => p.Seller)
            .HasForeignKey(p => p.SellerId);
    }
}