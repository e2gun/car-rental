using CarRental.Domain.Customers;

namespace CarRental.Infrastructure.Repositories;

internal sealed class CustomerRepository : Repository<Customer, CustomerId>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}