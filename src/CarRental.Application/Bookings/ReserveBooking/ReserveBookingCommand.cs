using CarRental.Application.Abstractions.Messaging;
using CarRental.Domain.Customers;
using CarRental.Domain.Vehicles;

namespace CarRental.Application.Bookings.ReserveBooking;

public record ReserveBookingCommand(
    VehicleId VehicleId,
    CustomerId CustomerId,
    DateTime StartDate,
    DateTime EndDate) : ICommand<Guid>;