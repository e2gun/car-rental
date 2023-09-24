using CarRental.Domain.Abstractions;
using CarRental.Domain.Vehicles.Models;

namespace CarRental.Domain.Vehicles.Brands;

public sealed class Brand : Entity<BrandId>
{
    public Brand(BrandId id,
        BrandName brandName,
        ModelId modelId) : base(id)
    {
        BrandName = brandName;
        ModelId = modelId;
    }

    private Brand()
    {
    }
    public BrandName BrandName { get; private set; }
    public ModelId ModelId { get; private set; }
}