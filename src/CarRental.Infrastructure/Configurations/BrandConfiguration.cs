using CarRental.Domain.Vehicles.Brands;
using CarRental.Domain.Vehicles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("brands");

        builder.HasKey(brand => brand.Id);
        
        builder.Property(brand => brand.Id)
            .HasConversion(brandId => brandId.Value, value => new BrandId(value));
        
        builder.Property(brand => brand.BrandName)
            .HasMaxLength(200)
            .HasConversion(brandName => brandName.Value, value => new BrandName(value));

        builder.HasOne<Model>()
            .WithMany()
            .HasForeignKey(brand => brand.ModelId);
    }
}