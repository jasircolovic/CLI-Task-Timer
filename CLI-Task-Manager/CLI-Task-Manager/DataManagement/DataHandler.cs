using System.Text.Json;
using CLI_Task_Timer.Models;

namespace CLI_Task_Timer.DataManagement
{
    public class DataHandler
    {
        private const string TaskFilePath = "tasks.json";
        private const string TimerFilePath = "timers.json";

        public void SaveTasks(List<TaskModel> tasks)
        {
            var json = JsonSerializer.Serialize(tasks);
            File.WriteAllText(TaskFilePath, json);
        }

        public List<TaskModel> LoadTasks()
        {
            if (!File.Exists(TaskFilePath)) return new List<TaskModel>();

            var json = File.ReadAllText(TaskFilePath);
            return JsonSerializer.Deserialize<List<TaskModel>>(json) ?? new List<TaskModel>();
        }

        public void SaveTimers(List<TimerModel> timers)
        {
            var json = JsonSerializer.Serialize(timers);
            File.WriteAllText(TimerFilePath, json);
        }

        public List<TimerModel> LoadTimers()
        {
            if (!File.Exists(TimerFilePath)) return new List<TimerModel>();

            var json = File.ReadAllText(TimerFilePath);
            return JsonSerializer.Deserialize<List<TimerModel>>(json) ?? new List<TimerModel>();
        }
    }
}