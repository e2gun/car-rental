using CarRental.Application.Abstractions.Messaging;
using CarRental.Domain.Bookings;

namespace CarRental.Application.Bookings.ConfirmBooking;

public sealed record ConfirmBookingCommand(BookingId BookingId) : ICommand;