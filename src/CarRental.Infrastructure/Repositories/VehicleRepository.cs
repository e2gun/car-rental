using CarRental.Domain.Vehicles;

namespace CarRental.Infrastructure.Repositories;

internal sealed class VehicleRepository : Repository<Vehicle, VehicleId>, IVehicleRepository
{
    public VehicleRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}