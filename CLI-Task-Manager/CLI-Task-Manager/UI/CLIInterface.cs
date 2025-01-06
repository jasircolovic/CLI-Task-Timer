using CLI_Task_Timer.Core;
using CLI_Task_Timer.Models;

namespace CLI_Task_Timer.UI
{
    public class CLIInterface
    {
        private readonly TaskManager _taskManager;
        private readonly TimerManager _timerManager;

        public CLIInterface(TaskManager taskManager, TimerManager timerManager)
        {
            _taskManager = taskManager;
            _timerManager = timerManager;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("=== CLI Task Timer ===");
            Console.WriteLine("1. List Tasks");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Edit Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Start Timer");
            Console.WriteLine("6. Pause Timer");
            Console.WriteLine("7. Resume Timer");
            Console.WriteLine("8. Stop Timer");
            Console.WriteLine("9. Exit");
            Console.Write("Select an option: ");
        }

        public void HandleUserInput()
        {
            bool exit = false;

            while (!exit)
            {
                DisplayMenu();
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        _taskManager.ListTasks();
                        break;
                    case "2":
                        AddTaskWorkflow();
                        break;
                    case "3":
                        EditTaskWorkflow();
                        break;
                    case "4":
                        DeleteTaskWorkflow();
                        break;
                    case "5":
                        StartTimerWorkflow();
                        break;
                    case "6":
                        PauseTimerWorkflow();
                        break;
                    case "7":
                        ResumeTimerWorkflow();
                        break;
                    case "8":
                        StopTimerWorkflow();
                        break;
                    case "9":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void AddTaskWorkflow()
        {
            Console.Write("Enter task name: ");
            var name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter tags (comma-separated): ");
            var tagsInput = Console.ReadLine() ?? string.Empty;
            var tags = new List<string>(tagsInput.Split(',', StringSplitOptions.RemoveEmptyEntries));

            _taskManager.AddTask(name, tags);
        }

        private void EditTaskWorkflow()
        {
            Console.Write("Enter task ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Enter new task name: ");
                var newName = Console.ReadLine() ?? string.Empty;

                Console.Write("Enter new tags (comma-separated): ");
                var tagsInput = Console.ReadLine() ?? string.Empty;
                var tags = new List<string>(tagsInput.Split(',', StringSplitOptions.RemoveEmptyEntries));

                _taskManager.EditTask(id, newName, tags);
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        private void DeleteTaskWorkflow()
        {
            Console.Write("Enter task ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _taskManager.DeleteTask(id);
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        private void StartTimerWorkflow()
        {
            Console.Write("Enter task ID to start timer: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _timerManager.StartTimer(id);
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        private void PauseTimerWorkflow()
        {
            Console.Write("Enter task ID to pause timer: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _timerManager.PauseTimer(id);
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        private void ResumeTimerWorkflow()
        {
            Console.Write("Enter task ID to resume timer: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _timerManager.ResumeTimer(id);
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        private void StopTimerWorkflow()
        {
            Console.Write("Enter task ID to stop timer: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _timerManager.StopTimer(id);
            }
            else
            {
                Console.WriteLine("Invalid task ID.");
            }
        }

        public void ShowTaskDetails(TaskModel task)
        {
            Console.WriteLine(
                $"ID: {task.Id}, Name: {task.Name}, Tags: {string.Join(", ", task.Tags)}, Total Time: {task.TotalTimeSpent}");
        }
    }
}
