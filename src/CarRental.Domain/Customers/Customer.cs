using CarRental.Domain.Abstractions;
using CarRental.Domain.Customers.Events;

namespace CarRental.Domain.Customers;

public sealed class Customer : Entity<CustomerId>
{
    private Customer(CustomerId id,
        FirstName firstName,
        LastName lastName,
        Email email,
        Phone phone) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
    }
    private Customer()
    {
        
    }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
    public Phone Phone { get; private set; }

    public static Customer Create(
        FirstName firstName,
        LastName lastName,
        Email email,
        Phone phone)
    {
        var customer = new Customer(CustomerId.New(), firstName, lastName, email, phone);

        customer.RaiseDomainEvent(new CustomerCreatedDomainEvents(customer.Id));
        
        return customer;
    }
}