using File.Classes;
using File.Enumes;
using Task = File.Classes.Task;

namespace File
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee Timur = new Employee("Тимур", "CEO");

            Employee Rashid = new Employee("Рашид", "FinanceDirector");
            Employee OIlham = new Employee("О Ильхам", "AutomationDirector");

            Timur.Subordinates.Add(Rashid);
            Timur.Subordinates.Add(OIlham);
            Rashid.Boss = Timur;
            OIlham.Boss = Timur;

            Employee Lucas = new Employee("Лукас", "Head", TaskType.Management);
            Rashid.Subordinates.Add(Lucas);
            Lucas.Boss = Rashid;

            Employee Orcadiy = new Employee("Оркадий", "Head", TaskType.Management);
            OIlham.Subordinates.Add(Orcadiy);
            Orcadiy.Boss = OIlham;

            Employee Volodya = new Employee("Володя", "Deputy", TaskType.Management);
            Orcadiy.Subordinates.Add(Volodya);
            Volodya.Boss = Orcadiy;

            // Сектор системщиков
            Employee Ilshat = new Employee("Ильшат", "Head", TaskType.SystemAdmins);
            Employee Ivanych = new Employee("Иваныч", "Deputy", TaskType.SystemAdmins);
            Employee Ilya = new Employee("Илья", "", TaskType.SystemAdmins);
            Employee Vitya = new Employee("Витя", "", TaskType.SystemAdmins);
            Employee Zhenya = new Employee("Женя", "", TaskType.SystemAdmins);

            Orcadiy.Subordinates.Add(Ilshat);
            Orcadiy.Subordinates.Add(Ivanych);
            Ilshat.Boss = Orcadiy;
            Ivanych.Boss = Orcadiy;

            Ilshat.Subordinates.Add(Ilya);
            Ilshat.Subordinates.Add(Vitya);
            Ilshat.Subordinates.Add(Zhenya);
            Ilya.Boss = Ilshat;
            Vitya.Boss = Ilshat;
            Zhenya.Boss = Ilshat;

            // Сектор разработчиков
            Employee Sergey = new Employee("Сергей", "Head", TaskType.Developers);
            Employee Laysan = new Employee("Ляйсан", "Deputy", TaskType.Developers);
            Employee Marat = new Employee("Марат", "", TaskType.Developers);
            Employee Dina = new Employee("Дина", "", TaskType.Developers);
            Employee Ildar = new Employee("Ильдар", "", TaskType.Developers);
            Employee Anton = new Employee("Антон", "", TaskType.Developers);

            Volodya.Subordinates.Add(Sergey);
            Volodya.Subordinates.Add(Laysan);
            Sergey.Boss = Volodya;
            Laysan.Boss = Sergey;

            Laysan.Subordinates.Add(Marat);
            Laysan.Subordinates.Add(Dina);
            Laysan.Subordinates.Add(Ildar);
            Laysan.Subordinates.Add(Anton);

            Marat.Boss = Laysan;
            Dina.Boss = Laysan;
            Ildar.Boss = Laysan;
            Anton.Boss = Laysan;

            List<Task> tasks = new List<Task>()
            {
                new Task("Настройка серверов", TaskType.SystemAdmins),
                new Task("Разработка новой функции", TaskType.Developers),
                new Task("Отчет для начальства", TaskType.Management)
            };
            foreach (var task in tasks)
            {
                Console.WriteLine($"\n--- Задача: {task.Name} ({task.Type}) ---");
                Timur.DistributeTask(task);
            }
        }
    }
}