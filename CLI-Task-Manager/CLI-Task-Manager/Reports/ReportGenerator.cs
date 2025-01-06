using CLI_Task_Timer.Models;

namespace CLI_Task_Timer.Reports
{
    public class ReportGenerator
    {
        public void GenerateSummaryReport(List<TaskModel> tasks)
        {
            Console.WriteLine("=== Task Time Summary Report ===");
            foreach (var task in tasks)
            {
                Console.WriteLine($"Task ID: {task.Id}, Name: {task.Name}, Total Time: {task.TotalTimeSpent}");
            }
        }

        public void FilterByDateRange(List<TaskModel> tasks, DateTime start, DateTime end)
        {
            var filteredTasks = tasks.Where(t => t.CreatedDate >= start && t.CreatedDate <= end).ToList();

            Console.WriteLine($"=== Tasks Created Between {start} and {end} ===");
            foreach (var task in filteredTasks)
            {
                Console.WriteLine($"Task ID: {task.Id}, Name: {task.Name}, Created: {task.CreatedDate}");
            }
        }
    }
}