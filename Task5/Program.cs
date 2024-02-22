using System;

//Создать консольное приложение для генерации случайных дат отпусков для каждого сотрудника в течение года.
//При этом должны соблюдаться следующие условия:
//-генерация происходит для дат с 1 января по 31 декабря включительно;
//-отпуск не может начинаться с выходного дня (суббота и воскресенье);
//-отпуск должен длиться 7 или 14 дней;
//-дни отпуска для каждого сотрудника должны быть разными, совпадений быть не должно;
//-в сумме должно быть 28 дней отпуска для каждого сотрудника.
//Результат генерации вывести в консоль.

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
