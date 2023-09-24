using CarRental.Domain.Vehicles;

namespace CarRental.Domain.Bookings;

public interface IBookingRepository
{
    Task<Booking?> GetByIdAsync(BookingId id, CancellationToken cancellationToken = default);

    Task<bool> IsOverlappingAsync(
        Vehicle vehicle,
        DateRange duration,
        CancellationToken cancellationToken = default);

    void Add(Booking booking);
}