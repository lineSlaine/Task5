//Создать консольное приложение для генерации случайных дат отпусков для каждого сотрудника в течение года.
//При этом должны соблюдаться следующие условия:
//-генерация происходит для дат с 1 января по 31 декабря включительно;
//-отпуск не может начинаться с выходного дня (суббота и воскресенье);
//-отпуск должен длиться 7 или 14 дней;
//-дни отпуска для каждого сотрудника должны быть разными, совпадений быть не должно;
//-в сумме должно быть 28 дней отпуска для каждого сотрудника.
//Результат генерации вывести в консоль.

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
