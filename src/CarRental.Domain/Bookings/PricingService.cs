using CarRental.Domain.Shared;
using CarRental.Domain.Vehicles;

namespace CarRental.Domain.Bookings;

public class PricingService
{
    public PricingDetails CalculatePrice(Vehicle vehicle, DateRange period)
    {
        var currency = vehicle.Price.Currency;

        var priceForPeriod = new Money(
            vehicle.Price.Amount * period.LengthInDays, currency
            );

        var percentageUpCharge = vehicle.Amenities.Sum(amenity => amenity switch
        {
            Amenity.Wifi => 0.05m,
            Amenity.BabySeat => 0.03m,
            _ => 0
        });

        var amenitiesUpCharge = Money.Zero(currency);

        if (percentageUpCharge > 0)
        {
            amenitiesUpCharge = new Money(
                priceForPeriod.Amount * percentageUpCharge,
                currency);
        }

        var totalPrice = Money.Zero(currency);

        totalPrice += priceForPeriod;
        totalPrice += amenitiesUpCharge;

        return new PricingDetails(priceForPeriod,amenitiesUpCharge,totalPrice);
    }
}