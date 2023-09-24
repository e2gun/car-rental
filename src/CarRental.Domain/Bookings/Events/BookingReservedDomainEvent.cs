using CarRental.Domain.Abstractions;

namespace CarRental.Domain.Bookings.Events;

public record BookingReservedDomainEvent(BookingId BookingId) : IDomainEvent;