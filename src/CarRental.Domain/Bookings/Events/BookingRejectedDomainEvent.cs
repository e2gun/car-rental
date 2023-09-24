using CarRental.Domain.Abstractions;

namespace CarRental.Domain.Bookings.Events;
public sealed record BookingRejectedDomainEvent(BookingId BookingId) : IDomainEvent;