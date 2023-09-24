using CarRental.Domain.Abstractions;

namespace CarRental.Domain.Vehicles;

public static class VehicleErrors
{
    public static Error NotFound = new(
        "Property.Found",
        "The property with the specified identifier was not found");
}