using CarRental.Domain.Abstractions;
using MediatR;

namespace CarRental.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}