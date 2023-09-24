using CarRental.Application.Abstractions.Email;

namespace CarRental.Infrastructure.Email;

internal sealed class EmailService : IEmailService
{
    public Task SendAsync(Domain.Customers.Email recipient, string subject, string body)
    {
        return Task.CompletedTask;
    }
}