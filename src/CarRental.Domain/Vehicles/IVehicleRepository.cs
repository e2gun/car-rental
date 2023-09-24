namespace CarRental.Domain.Vehicles;

public interface IVehicleRepository
{
    Task<Vehicle?> GetByIdAsync(VehicleId id,CancellationToken cancellationToken = default);
}