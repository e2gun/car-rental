using CarRental.Domain.Shared;

namespace CarRental.Domain.Bookings;

public record PricingDetails(
    Money PriceForPeriod,
    Money AmenitiesUpCharge,
    Money TotalPrice
    );