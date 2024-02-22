namespace Task5;

internal class Employee
{
    public Employee(string name)
    {
        Name = name;
        Vacations = new List<StartEndDate>();
    }

    public Employee(string name, IEnumerable<StartEndDate> vacations) : this(name)
    {
        Vacations = vacations;
    }

    public string Name { get; init; }
    public IEnumerable<StartEndDate> Vacations { get; set; }
}           
