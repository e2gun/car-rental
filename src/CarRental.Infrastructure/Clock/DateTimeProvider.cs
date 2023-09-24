using CarRental.Application.Abstractions.Clock;

namespace CarRental.Infrastructure.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}