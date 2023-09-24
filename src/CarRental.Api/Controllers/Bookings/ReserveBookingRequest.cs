namespace CarRental.Api.Controllers.Bookings;

public sealed record ReserveBookingRequest(
    Guid VehicleId,
    Guid CustomerId,
    DateTime StartDate,
    DateTime EndDate
    );