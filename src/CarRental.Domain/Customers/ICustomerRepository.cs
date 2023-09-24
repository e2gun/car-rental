namespace CarRental.Domain.Customers;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(CustomerId id,CancellationToken cancellationToken);

    void Add(Customer customer);
}