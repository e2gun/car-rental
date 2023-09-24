using CarRental.Domain.Abstractions;

namespace CarRental.Domain.Reviews;

public sealed record Rating
{
    public static readonly Error Invalid = new("Rating.Invalid", "The rating is invalid");

    private Rating(int value) => Value = value;

    public int Value { get; init; }

    public static Result<Rating> Create(int value)
    {
        return value is < 1 or > 5 ? Result.Failure<Rating>(Invalid) : new Rating(value);
    }
}