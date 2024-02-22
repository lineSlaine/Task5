using System;
namespace Task5;

internal class Program
{
    static void Main(string[] args)
    {
        int employeesCount = 0;
        var check = false;
        while (!check) 
        {
            Console.Write("Введите кол-во сотрудников: ");
            try
            {
                employeesCount = Convert.ToInt16(Console.ReadLine());
                check = true;
                
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Попробуйте ввести число!");
            }
        }

        var employeeService = new EmployeeService(employeesCount);
        foreach (var employee in employeeService.Employees)
        {
            employee.Vacations = employeeService.GenerateVacationDate();
        }
        Console.Clear();
        
        foreach(var employee in employeeService.Employees)
        {
            Console.WriteLine($"\n{employee.Name}");
            foreach(var date in employee.Vacations)
            {
                Console.WriteLine($"c {date.StartDate} по {date.EndDate}");
            }
        }
    }
}
