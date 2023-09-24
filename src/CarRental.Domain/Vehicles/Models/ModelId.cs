namespace CarRental.Domain.Vehicles.Models;

public record ModelId(Guid Value)
{
    public static ModelId New() => new(Guid.NewGuid());
}