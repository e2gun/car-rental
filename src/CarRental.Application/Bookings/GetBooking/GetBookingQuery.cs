using CarRental.Application.Abstractions.Messaging;

namespace CarRental.Application.Bookings.GetBooking;

public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>;