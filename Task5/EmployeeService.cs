namespace Task5;

internal class EmployeeService
{
    public IEnumerable<Employee> Employees { get; init;}

    public EmployeeService(int count)
    {

        Employees = GenerateEmployees(count);
    }

    public IEnumerable<Employee> GenerateEmployees(int count)
    {
        var employees = new List<Employee>();
        for(var i = 1; i <= count; i++)
        {
            employees.Add(new Employee ($"Сотрудник {i}"));
        }
        return employees;
    }

    private DateOnly GenerateDateWithoutWeekends()
    {
        var startDate = new DateOnly();
        do
        {
            startDate = new DateOnly(DateTime.Today.Year, new Random().Next(1, 13), 1);
            startDate = startDate.AddDays(new Random().Next(0, 32));
        }
        while (startDate.DayOfWeek.Equals("Saturday") || startDate.DayOfWeek.Equals("Sunday"));

        return startDate;
    }

    public IEnumerable<StartEndDate> GenerateVacationDate()
    {
        var days = 28;
        const int CountDaysOfWeek = 7;
        int choice = 1;
        var dates = new List<StartEndDate>();

        while (days > 0)
        {
            var startDate = GenerateDateWithoutWeekends();
            
            if (days != CountDaysOfWeek)
            {
                choice = new Random().Next(1, 3);
            }
            
            var endDate = startDate.AddDays(CountDaysOfWeek * choice -1);
            if(endDate.Year != DateTime.Today.Year + 1)
            {
                bool checkDate = true;
                foreach(var employee in Employees)
                {
                    checkDate = checkDate && VerificateVacation(startDate, endDate, employee.Vacations); 
                }

                if(VerificateVacation(startDate, endDate, dates) && checkDate)
                {
                    
                    days -= CountDaysOfWeek * choice;
                    dates.Add(new StartEndDate(startDate,endDate));
                }
            }
        }
        return dates;
    }
    public bool VerificateVacation(DateOnly startDate, DateOnly endDate, IEnumerable<StartEndDate> Vacations)
    {
        if (Vacations.Count() != 0)
        {
            foreach (var vacation in Vacations)
            {
                if (vacation.StartDate <= startDate && startDate <= vacation.EndDate)
                {
                    return false;
                }
                else if (vacation.StartDate <= endDate && endDate <= vacation.EndDate)
                {
                    return false;
                }
                else if(startDate <= vacation.StartDate && vacation.StartDate <= endDate)
                {
                    return false;
                }
                else if (startDate <= vacation.EndDate && vacation.EndDate <= endDate)
                {
                    return false;
                }
            }
        }
        return true;
    }
}