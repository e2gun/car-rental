using CarRental.Domain.Abstractions;
using CarRental.Domain.Shared;
using CarRental.Domain.Vehicles.Brands;

namespace CarRental.Domain.Vehicles;

public sealed class Vehicle : Entity<VehicleId>
{
    public Vehicle(VehicleId id, 
        Plate plate,
        Address address,
        BrandId brandId,
        Description description,
        Money price,
        DateTime createdOnUtc
        ) : base(id)
    {
        Plate = plate;
        Address = address;
        BrandId = brandId;
        Description = description;
        Price = price;
        CreatedOnUtc = createdOnUtc;
    }

    private Vehicle()
    {
        
    }
    public Plate Plate { get; private set; }
    public Description Description { get; private set; }
    public Address Address { get; private set; }
    public BrandId? BrandId { get; private set; }
    public Money Price { get; private set; }
    public DateTime CreatedOnUtc { get;private  set; }
    public DateTime? LastBookedOnUtc { get; internal set; }
    public List<Amenity> Amenities { get; private set; } = new();
}