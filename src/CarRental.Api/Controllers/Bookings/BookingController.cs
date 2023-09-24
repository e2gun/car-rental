using CarRental.Application.Bookings.GetBooking;
using CarRental.Application.Bookings.ReserveBooking;
using CarRental.Domain.Customers;
using CarRental.Domain.Vehicles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers.Bookings;

[ApiController]
[Route("api/bookings")]
public class BookingController : ControllerBase
{
    private readonly ISender _sender;

    public BookingController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> GetBooking(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetBookingQuery(id);
        
        var result = await _sender.Send(query,cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }
    
    [HttpPost]
    public async Task<IActionResult> ReserveBooking(
        ReserveBookingRequest request,
        CancellationToken cancellationToken)
    {
        var command = new ReserveBookingCommand(new VehicleId(request.VehicleId),
            new CustomerId(request.CustomerId),
            request.StartDate,
            request.EndDate);
        
        var result = await _sender.Send(command,cancellationToken);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        return CreatedAtAction(nameof(GetBooking), new { id = result.Value }, result.Value);
    }
}