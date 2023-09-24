using CarRental.Domain.Abstractions;

namespace CarRental.Domain.Vehicles.Models;

public sealed class Model : Entity<ModelId>
{
    public Model(ModelId id,
        ModelName modelName) : base(id)
    {
        ModelName = modelName;
    }
    private Model()
    {
    }
    public ModelName ModelName { get; set; }
}