using CarRental.Domain.Abstractions;

namespace CarRental.Domain.Bookings.Events;
public sealed record BookingConfirmedDomainEvent(BookingId BookingId) : IDomainEvent;