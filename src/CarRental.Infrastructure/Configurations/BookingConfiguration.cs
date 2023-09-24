using CarRental.Domain.Vehicles;
using CarRental.Domain.Bookings;
using CarRental.Domain.Shared;
using CarRental.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Configurations;

internal sealed class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("bookings");

        builder.HasKey(booking => booking.Id);

        builder.Property(booking => booking.Id)
            .HasConversion(bookingId => bookingId.Value, value => new BookingId(value));

        builder.OwnsOne(booking => booking.PriceForPeriod, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.GetCode(code));
        });

        builder.OwnsOne(booking => booking.AmenitiesUpCharge, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.GetCode(code));
        });

        builder.OwnsOne(booking => booking.TotalPrice, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.GetCode(code));
        });

        builder.OwnsOne(booking => booking.Duration);

        builder.HasOne<Vehicle>()
            .WithMany()
            .HasForeignKey(booking => booking.VehicleId);

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(booking => booking.CustomerId);
    }
}