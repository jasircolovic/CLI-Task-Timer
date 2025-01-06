using CLI_Task_Timer.Core;
using CLI_Task_Timer.DataManagement;
using CLI_Task_Timer.Models;
using CLI_Task_Timer.UI;
using CLI_Task_Timer.Reports;

namespace CLI_Task_Timer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Initialize data handler and load existing data
            var dataHandler = new DataHandler();
            List<TaskModel> tasks = dataHandler.LoadTasks();
            List<TimerModel> timers = dataHandler.LoadTimers();

            // Instantiate managers
            var taskManager = new TaskManager(tasks);
            var timerManager = new TimerManager(timers, taskManager);

            // 2) Instantiate the ReportGenerator
            var reportGenerator = new ReportGenerator();

            // (Optional) Generate a summary report for tasks before the CLI
            Console.WriteLine("\n=== Task Summary Report (Before CLI) ===");
            reportGenerator.GenerateSummaryReport(tasks);

            // (Optional) Filter tasks by date range; here, we use the last 7 days
            var startDate = DateTime.Now.AddDays(-7);
            var endDate = DateTime.Now;
            Console.WriteLine($"\n=== Filter Tasks Created Between {startDate} and {endDate} ===");
            reportGenerator.FilterByDateRange(tasks, startDate, endDate);

            // Set up the CLI interface
            var cli = new CLIInterface(taskManager, timerManager);

            // Run the CLI
            cli.HandleUserInput();

            // (Optional) Generate a summary report for tasks after the CLI
            Console.WriteLine("\n=== Task Summary Report (After CLI) ===");
            reportGenerator.GenerateSummaryReport(taskManager.GetAllTasks());

            // Save data before exiting
            dataHandler.SaveTasks(taskManager.GetAllTasks());
            dataHandler.SaveTimers(timerManager.GetAllTimers());
        }
    }
}