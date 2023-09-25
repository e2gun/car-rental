using CarRental.Application.Abstractions.Data;
using CarRental.Application.Abstractions.Messaging;
using CarRental.Domain.Abstractions;
using CarRental.Domain.Bookings;
using Dapper;

namespace CarRental.Application.Vehicles.SearchVehicles;

internal sealed class SearchVehiclesQueryHandler
    : IQueryHandler<SearchVehiclesQuery, IReadOnlyList<VehicleResponse>>
{
    private static readonly int[] ActiveBookingStatuses =
    {
        (int)BookingStatus.Reserved,
        (int)BookingStatus.Confirmed,
        (int)BookingStatus.Completed
    };

    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public SearchVehiclesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<VehicleResponse>>> Handle(SearchVehiclesQuery request, CancellationToken cancellationToken)
    {
        if (request.StartDate > request.EndDate)
        {
            return new List<VehicleResponse>();
        }

        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
            SELECT
                a.id AS Id,
                a.plate AS Plate,
                a.description AS Description,
                a.price_amount AS Price,
                a.price_currency AS Currency,
                a.address_country AS Country,
                a.address_state AS State,
                a.address_city AS City,
                a.address_street AS Street,
                a.address_map_location AS MapLocation
            FROM vehicles AS a
            WHERE NOT EXISTS
            (
                SELECT 1
                FROM bookings AS b
                WHERE
                    b.vehicle_id = a.id AND
                    b.duration_start <= @EndDate AND
                    b.duration_end >= @StartDate AND
                    b.status = ANY(@ActiveBookingStatuses)
            )
            """;

        var vehicles = await connection
            .QueryAsync<VehicleResponse, AddressResponse, VehicleResponse>(
                sql,
                (vehicle, address) =>
                {
                    vehicle.Address = address;

                    return vehicle;
                },
                new
                {
                    request.StartDate,
                    request.EndDate,
                    ActiveBookingStatuses
                },
                splitOn: "Country");

        return vehicles.ToList();
    }
}