using CarRental.Domain.Abstractions;
using CarRental.Domain.Bookings;
using CarRental.Domain.Customers;
using CarRental.Domain.Reviews.Events;
using CarRental.Domain.Vehicles;

namespace CarRental.Domain.Reviews;

public sealed class Review : Entity<ReviewId>
{
    private Review(
        ReviewId id,
        VehicleId vehicleId,
        BookingId bookingId,
        CustomerId customerId,
        Rating rating,
        Comment comment,
        DateTime createdOnUtc)
        : base(id)
    {
        VehicleId = vehicleId;
        BookingId = bookingId;
        CustomerId = customerId;
        Rating = rating;
        Comment = comment;
        CreatedOnUtc = createdOnUtc;
    }
    
    private Review()
    {
        
    }

    public VehicleId VehicleId { get; private set; }

    public BookingId BookingId { get; private set; }

    public CustomerId CustomerId { get; private set; }

    public Rating Rating { get; private set; }

    public Comment Comment { get; private set; }

    public DateTime CreatedOnUtc { get; private set; }

    public static Result<Review> Create(
        Booking booking,
        Rating rating,
        Comment comment,
        DateTime createdOnUtc)
    {
        if (booking.Status != BookingStatus.Completed)
        {
            return Result.Failure<Review>(ReviewErrors.NotEligible);
        }

        var review = new Review(
            ReviewId.New(),
            booking.VehicleId,
            booking.Id,
            booking.CustomerId,
            rating,
            comment,
            createdOnUtc);

        review.RaiseDomainEvent(new ReviewCreatedDomainEvent(review.Id));

        return review;
    }
}