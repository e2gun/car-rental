using CarRental.Domain.Abstractions;

namespace CarRental.Domain.Reviews.Events;

public sealed record ReviewCreatedDomainEvent(ReviewId ReviewId) : IDomainEvent;