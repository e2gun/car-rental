using CarRental.Domain.Abstractions;

namespace CarRental.Domain.Bookings.Events;

public sealed record BookingCancelledDomainEvent(BookingId BookingId) : IDomainEvent;