namespace CarRental.Application.Vehicles.SearchVehicles;

public sealed class AddressResponse
{
    public string Country { get; init; }

    public string State { get; init; }

    public string City { get; init; }

    public string Street { get; init; }
    
    public string MapLocation { get; init; }
}