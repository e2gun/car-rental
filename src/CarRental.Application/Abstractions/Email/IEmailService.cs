namespace CarRental.Application.Abstractions.Email;

public interface IEmailService
{
    Task SendAsync(Domain.Customers.Email recipient, string subject, string body);
}