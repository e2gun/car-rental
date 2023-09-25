using Bogus;
using CarRental.Application.Abstractions.Data;
using CarRental.Domain.Vehicles;
using Dapper;

namespace CarRental.Api.Extensions;

public static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using var connection = sqlConnectionFactory.CreateConnection();

        var faker = new Faker();

        List<object> vehicles = new();
        
        for (var i = 0; i < 100; i++)
        {
            vehicles.Add(new
            {
                Id = Guid.NewGuid(),
                Plate = faker.Company.CompanyName(),
                Description = "Car Rental",
                Country = faker.Address.Country(),
                State = faker.Address.State(),
                City = faker.Address.City(),
                Street = faker.Address.StreetAddress(),
                MapLocation = $"{faker.Address.Latitude()},{faker.Address.Longitude()}",
                PriceAmount = faker.Random.Decimal(50, 1000),
                PriceCurrency = "TRY",
                Amenities = new List<int> { (int)Amenity.Wifi, (int)Amenity.BabySeat },
                CreatedOnUtc = DateTime.Now,
                LastBookedOn = DateTime.MinValue
            });
        }

        const string sql = """
                           INSERT INTO public.vehicles
                           (id, "plate", description, address_country, address_state, address_map_location, address_city, address_street, price_amount, price_currency, amenities,created_on_utc, last_booked_on_utc)
                           VALUES(@Id, @Plate, @Description, @Country, @State, @City, @Street, @MapLocation, @PriceAmount, @PriceCurrency, @Amenities,@CreatedOnUtc, @LastBookedOn);
                           """;

        connection.Execute(sql, vehicles);
        
        
    }
}