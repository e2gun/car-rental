using CarRental.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Configurations;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("customers");

        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.Id)
            .HasConversion(customerId => customerId.Value, value => new CustomerId(value));
        
        builder.Property(customer => customer.FirstName)
            .HasMaxLength(200)
            .HasConversion(firstName => firstName.Value, value => new FirstName(value));

        builder.Property(customer => customer.LastName)
            .HasMaxLength(200)
            .HasConversion(firstName => firstName.Value, value => new LastName(value));

        builder.Property(customer => customer.Email)
            .HasMaxLength(400)
            .HasConversion(email => email.Value, value => new Domain.Customers.Email(value)); ;

        builder.Property(customer => customer.Phone)
            .HasMaxLength(30)
            .HasConversion(phone => phone.Value, value => new Phone(value)); ;

        builder.HasIndex(customer => customer.Email).IsUnique();
    }
}
