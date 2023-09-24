using CarRental.Domain.Abstractions;

namespace CarRental.Domain.Customers.Events;

public sealed record CustomerCreatedDomainEvents(CustomerId CustomerId): IDomainEvent;