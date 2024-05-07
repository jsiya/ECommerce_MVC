using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
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
            .HasColumnType("nvarchar(30)")
            .IsRequired();
        builder.Property(c => c.Address)
            .HasColumnType("nvarchar(150)");
        builder.Property(c => c.UserRole)
            .HasDefaultValue("Customer");
        
        //relations
        builder.HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);
    }
}