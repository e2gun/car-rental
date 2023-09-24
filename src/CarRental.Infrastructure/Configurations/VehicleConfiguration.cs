using CarRental.Domain.Shared;
using CarRental.Domain.Vehicles;
using CarRental.Domain.Vehicles.Brands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Configurations;

internal sealed class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("vehicles");

        builder.HasKey(vehicle => vehicle.Id);

        builder.OwnsOne(vehicle => vehicle.Address);
        
        builder.Property(vehicle => vehicle.Id)
            .HasConversion(vehicleId => vehicleId.Value, value => new VehicleId(value));

        builder.Property(vehicle => vehicle.Plate)
            .HasMaxLength(100)
            .HasConversion(name => name.Value, value => new Plate(value));

        builder.Property(vehicle => vehicle.Description)
            .HasMaxLength(2000)
            .HasConversion(description => description.Value, value => new Description(value));

        builder.OwnsOne(vehicle => vehicle.Price, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.GetCode(code));
        });

        builder.HasOne<Brand>()
            .WithMany()
            .HasForeignKey(vehicle => vehicle.BrandId);

        builder.Property<uint>("Version").IsRowVersion();
    }
}