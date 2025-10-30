using File.Enumes;

namespace File.Classes
{
    internal class Employee
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public Employee Boss { get; set; }
        public List<Employee> Subordinates { get; set; } = new List<Employee>();
        public TaskType DepartmentType { get; set; }
        public Employee(string name, string role = "", TaskType departmentType = TaskType.Management)
        {
            Name = name;
            Role = role;
            DepartmentType = departmentType;
        }

        /// <summary> Получает задачу от начальника </summary>
        /// <param name="from">тот, кто дает задачу</param>
        /// <param name="task">задача</param>
        public void ReceiveTask(Employee from, Task task)
        {
            bool canTake = false;
            if (from == Boss)
            {
                if (task.Type == DepartmentType || Role == "Head" || Role == "Deputy")
                    canTake = true;
            }

            string status = canTake ? "берёт задачу" : "НЕ берёт задачу";
            Console.WriteLine($"{from.Name} даёт задачу '{task.Name}' {Name} -> {status}");
        }

        /// <summary> Раздача задачи сотрудникам </summary>
        /// <param name="task">задача</param>
        public void DistributeTask(Task task)
        {
            foreach (var sub in Subordinates)
            {
                sub.ReceiveTask(this, task);
                sub.DistributeTask(task);
            }
        }
    }
}

