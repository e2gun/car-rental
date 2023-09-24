using CarRental.Application.Abstractions.Messaging;

namespace CarRental.Application.Vehicles.SearchVehicles;

public sealed record SearchVehiclesQuery(
    DateTime StartDate,
    DateTime EndDate) : IQuery<IReadOnlyList<VehicleResponse>>;