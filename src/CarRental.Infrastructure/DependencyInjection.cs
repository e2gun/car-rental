using CarRental.Application.Abstractions.Clock;
using CarRental.Application.Abstractions.Data;
using CarRental.Application.Abstractions.Email;
using CarRental.Domain.Abstractions;
using CarRental.Domain.Vehicles;
using CarRental.Domain.Bookings;
using CarRental.Domain.Customers;
using CarRental.Infrastructure.Clock;
using CarRental.Infrastructure.Data;
using CarRental.Infrastructure.Email;
using CarRental.Infrastructure.Repositories;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        services.AddTransient<IEmailService, EmailService>();

        var connectionString =
            configuration.GetConnectionString("Database") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention();
        });

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddScoped<IVehicleRepository, VehicleRepository>();

        services.AddScoped<IBookingRepository, BookingRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

        return services;
    }
}