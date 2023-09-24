using CarRental.Application.Abstractions.Email;
using CarRental.Domain.Bookings;
using CarRental.Domain.Bookings.Events;
using CarRental.Domain.Customers;
using MediatR;

namespace CarRental.Application.Bookings.ReserveBooking;

internal sealed class BookingReservedDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IEmailService _emailService;

    public BookingReservedDomainEventHandler(
        IBookingRepository bookingRepository,
        ICustomerRepository customerRepository,
        IEmailService emailService)
    {
        _bookingRepository = bookingRepository;
        _customerRepository = customerRepository;
        _emailService = emailService;
    }

    public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);

        if (booking is null)
        {
            return;
        }

        var customer = await _customerRepository.GetByIdAsync(booking.CustomerId, cancellationToken);

        if (customer is null)
        {
            return;
        }

        await _emailService.SendAsync(
            customer.Email,
            "Booking reserved!",
            "You have 10 minutes to confirm this booking");
    }
}