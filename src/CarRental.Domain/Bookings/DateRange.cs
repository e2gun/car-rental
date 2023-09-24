namespace CarRental.Domain.Bookings;

public record DateRange
{
    private DateRange()
    {
        
    }
    public DateTime Start { get; init; }
    public DateTime End { get; init; }

    public int LengthInDays => End.Day - Start.Day == 0 ? 1 : End.Day - Start.Day;

    public static DateRange Create(DateTime start, DateTime end)
    {
        if (start > end)
        {
            throw new ApplicationException("End date precedes start date");
        }
        
        return new DateRange
        {
            Start = start,
            End = end
        };
    }
}