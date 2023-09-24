using CarRental.Domain.Vehicles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Configurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("models");

        builder.HasKey(model => model.Id);
        
        builder.Property(model => model.Id)
            .HasConversion(modelId => modelId.Value, value => new ModelId(value));
        
        builder.Property(model => model.ModelName)
            .HasMaxLength(200)
            .HasConversion(modelName => modelName.Value, value => new ModelName(value));
    }
}