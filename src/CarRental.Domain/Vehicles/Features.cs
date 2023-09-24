using CarRental.Domain.Vehicles.Brands;
using CarRental.Domain.Vehicles.Models;

namespace CarRental.Domain.Vehicles;
public record Features(BrandId BrandId,ModelId ModelId);