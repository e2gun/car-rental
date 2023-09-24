using CarRental.Domain.Abstractions;

namespace CarRental.Domain.Customers;

public static class CustomerErrors
{
    public static Error NotFound = new(
        "Customer.Found",
        "The user with the specified identifier was not found");

    public static Error InvalidCredentials = new(
        "Customer.InvalidCredentials",
        "The provided credentials were invalid");
}