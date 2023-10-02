using CarRental.Application.Abstractions.Clock;
using CarRental.Application.Bookings.ReserveBooking;
using CarRental.Domain.Abstractions;
using CarRental.Domain.Vehicles;
using CarRental.Domain.Bookings;
using CarRental.Domain.Customers;
using FluentAssertions;
using Moq;

namespace CarRental.Application.UnitTests.Bookings;

public class ReserveBookingTests
{
    private static readonly Customer Customer = Customer.Create(
        new FirstName("test"),
        new LastName("test"),
        new Email("test@test.com"),
        new Phone("5555556688"));

    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenCustomerIsNull()
    {
        // Arrange
        var command = new ReserveBookingCommand(
            new VehicleId(Guid.NewGuid()),
            new CustomerId(Guid.NewGuid()),
            DateTime.Parse("01-01-2023"),
            DateTime.Parse("10-01-2023"));

        var customerRepositoryMock = new Mock<ICustomerRepository>();
        customerRepositoryMock
            .Setup(u => u.GetByIdAsync(It.IsAny<CustomerId>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Customer?)null);

        var handler = new ReserveBookingCommandHandler(
            customerRepositoryMock.Object,
            new Mock<IVehicleRepository>().Object,
            new Mock<IBookingRepository>().Object,
            new Mock<IUnitOfWork>().Object,
            new Mock<PricingService>().Object,
            new Mock<IDateTimeProvider>().Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.Error.Should().Be(CustomerErrors.NotFound);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenVehicleIsNull()
    {
        // Arrange
        var command = new ReserveBookingCommand(
            new VehicleId(Guid.NewGuid()),
            new CustomerId(Guid.NewGuid()),
            DateTime.Parse("01-01-2023"),
            DateTime.Parse("10-01-2023"));

        var customerRepositoryMock = new Mock<ICustomerRepository>();
        customerRepositoryMock
            .Setup(u => u.GetByIdAsync(It.IsAny<CustomerId>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Customer);

        var apartmentRepositoryMock = new Mock<IVehicleRepository>();
        apartmentRepositoryMock
            .Setup(u => u.GetByIdAsync(It.IsAny<VehicleId>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Vehicle?)null);


        var handler = new ReserveBookingCommandHandler(
            customerRepositoryMock.Object,
            apartmentRepositoryMock.Object,
            new Mock<IBookingRepository>().Object,
            new Mock<IUnitOfWork>().Object,
            new Mock<PricingService>().Object,
            new Mock<IDateTimeProvider>().Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.Error.Should().Be(VehicleErrors.NotFound);
    }
}