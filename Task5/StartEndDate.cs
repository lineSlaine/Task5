namespace Task5;

internal class StartEndDate
{
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    public StartEndDate(DateOnly startDate, DateOnly endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }
}