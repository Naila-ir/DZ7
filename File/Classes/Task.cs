using File.Enumes;

namespace File.Classes
{
    internal class Task
    {
        public string Name { get; set; }
        public TaskType Type { get; set; }
        public Task(string name, TaskType type)
        {
            Name = name;
            Type = type;
        }
    }
}
