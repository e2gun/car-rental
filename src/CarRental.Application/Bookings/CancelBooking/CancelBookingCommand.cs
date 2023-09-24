using CarRental.Application.Abstractions.Messaging;
using CarRental.Domain.Bookings;

namespace CarRental.Application.Bookings.CancelBooking;

public record CancelBookingCommand(BookingId BookingId) : ICommand;