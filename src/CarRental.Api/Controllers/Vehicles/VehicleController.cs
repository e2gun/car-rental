using CarRental.Application.Vehicles.SearchVehicles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers.Vehicles;

[ApiController]
[Route("api/vehicles")]
public class VehicleController : ControllerBase
{
    private readonly ISender _sender;

    public VehicleController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> SearchVehicles(
        DateTime startDate, 
        DateTime endDate,
        CancellationToken cancellationToken)
    {
        var query = new SearchVehiclesQuery(startDate, endDate);

        var result = await _sender.Send(query, cancellationToken);

        return Ok(result.Value);
    }
}