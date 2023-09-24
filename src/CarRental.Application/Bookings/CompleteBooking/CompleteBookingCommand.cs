using CarRental.Application.Abstractions.Messaging;
using CarRental.Domain.Bookings;

namespace CarRental.Application.Bookings.CompleteBooking;

public record CompleteBookingCommand(BookingId BookingId) : ICommand;