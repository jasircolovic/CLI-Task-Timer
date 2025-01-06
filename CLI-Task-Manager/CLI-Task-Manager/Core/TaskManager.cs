using CLI_Task_Timer.Models;

namespace CLI_Task_Timer.Core
{
    public class TaskManager
    {
        private readonly List<TaskModel> _tasks;

        public TaskManager(List<TaskModel> initialTasks)
        {
            _tasks = initialTasks;
        }

        public void AddTask(string name, List<string> tags)
        {
            int newId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;

            var newTask = new TaskModel
            {
                Id = newId,
                Name = name,
                Tags = tags,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                TotalTimeSpent = TimeSpan.Zero
            };

            _tasks.Add(newTask);
            Console.WriteLine($"Task '{name}' added with ID {newId}.");
        }

        
        public void ListTasks()
        {
            if (!_tasks.Any())
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            foreach (var task in _tasks)
            {
                Console.WriteLine($"ID: {task.Id}, Name: {task.Name}, Tags: {string.Join(", ", task.Tags)}, " +
                                  $"Time Spent: {task.TotalTimeSpent}");
            }
        }

        public void DeleteTask(int taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                Console.WriteLine($"No task found with ID {taskId}");
                return;
            }

            _tasks.Remove(task);
            Console.WriteLine($"Task ID {taskId} deleted successfully.");
        }

        // Optional getter for advanced usage
        public TaskModel? GetTask(int taskId) => _tasks.FirstOrDefault(t => t.Id == taskId);

        public List<TaskModel> GetAllTasks() => _tasks;
    }
}
