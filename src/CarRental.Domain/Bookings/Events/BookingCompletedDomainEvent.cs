using CarRental.Domain.Abstractions;

namespace CarRental.Domain.Bookings.Events;
public sealed record BookingCompletedDomainEvent(BookingId BookingId) : IDomainEvent;