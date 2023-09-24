namespace CarRental.Domain.Shared;

public record Currency
{
    internal static readonly Currency None = new("");
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Eur = new("EUR");
    public static readonly Currency Tr = new("TR");
    private Currency(string code)
    {
        Code = code;
    }
    public string Code { get; init; }

    public static Currency GetCode(string code)
    {
        return All.FirstOrDefault(s => s.Code == code)
               ?? throw new ApplicationException("Currency code is invalid");
    }

    public static readonly IReadOnlyCollection<Currency> All = new[]
    {
        Usd,
        Eur,
        Tr
    };
}