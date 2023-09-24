namespace CarRental.Application.Bookings.GetBooking;

public sealed class BookingResponse
{
    public Guid Id { get; init; }

    public Guid CustomerId { get; init; }

    public Guid VehicleId { get; init; }
    
    public int Status { get; init; }

    public decimal PriceAmount { get; init; }

    public string PriceCurrency { get; init; }

    public decimal AmenitiesUpChargeAmount { get; init; }

    public string AmenitiesUpChargeCurrency { get; init; }

    public decimal TotalPriceAmount { get; init; }

    public string TotalPriceCurrency { get; init; }

    public DateOnly DurationStart { get; init; }

    public DateOnly DurationEnd { get; init; }

    public DateTime CreatedOnUtc { get; init; }
}