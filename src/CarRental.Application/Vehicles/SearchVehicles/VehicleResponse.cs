namespace CarRental.Application.Vehicles.SearchVehicles;

public sealed class VehicleResponse
{
    public Guid Id { get; init; }

    public string Plate { get; init; }

    public string Description { get; init; }

    public decimal Price { get; init; }

    public string Currency { get; init; }
    public AddressResponse Address { get; set; }
}