using CarRental.Application.Abstractions.Messaging;
using CarRental.Domain.Bookings;

namespace CarRental.Application.Bookings.RejectBooking;

public sealed record RejectBookingCommand(BookingId BookingId) : ICommand;