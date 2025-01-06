using CLI_Task_Timer.Models;

namespace CLI_Task_Timer.Core
{
    public class TimerManager
    {
        private readonly List<TimerModel> _timers;
        private readonly TaskManager _taskManager;

        public TimerManager(List<TimerModel> initialTimers, TaskManager taskManager)
        {
            _timers = initialTimers;
            _taskManager = taskManager;
        }

        public void StartTimer(int taskId)
        {
            var task = _taskManager.GetTask(taskId);
            if (task == null)
            {
                Console.WriteLine($"Task {taskId} not found.");
                return;
            }

            var timer = _timers.FirstOrDefault(t => t.TaskId == taskId);
            if (timer == null)
            {
                timer = new TimerModel
                {
                    TaskId = taskId,
                    StartTime = DateTime.Now,
                    IsPaused = false,
                    ElapsedTime = TimeSpan.Zero
                };
                _timers.Add(timer);
            }
            else
            {
                // If paused or stopped, reset its StartTime
                if (timer.IsPaused)
                {
                    timer.IsPaused = false;
                    timer.StartTime = DateTime.Now;
                }
            }

            Console.WriteLine($"Timer started for Task ID {taskId} at {timer.StartTime}");
        }

        public void PauseTimer(int taskId)
        {
            var timer = _timers.FirstOrDefault(t => t.TaskId == taskId);
            if (timer == null || timer.StartTime == null)
            {
                Console.WriteLine($"No active timer found for Task ID {taskId}");
                return;
            }

            if (!timer.IsPaused)
            {
                timer.ElapsedTime += DateTime.Now - timer.StartTime.Value;
                timer.IsPaused = true;
                timer.StartTime = null;
                Console.WriteLine($"Timer paused for Task ID {taskId}");
            }
            else
            {
                Console.WriteLine($"Timer is already paused for Task ID {taskId}");
            }
        }

        public void StopTimer(int taskId)
        {
            var timer = _timers.FirstOrDefault(t => t.TaskId == taskId);
            if (timer == null || timer.StartTime == null)
            {
                Console.WriteLine($"No active timer found for Task ID {taskId}");
                return;
            }

            var task = _taskManager.GetTask(taskId);
            if (task == null) return;

            if (!timer.IsPaused)
            {
                timer.ElapsedTime += DateTime.Now - timer.StartTime.Value;
            }

            // Update the task’s total time spent
            task.TotalTimeSpent += timer.ElapsedTime;
            task.LastModifiedDate = DateTime.Now;

            // Remove the timer from active collection
            _timers.Remove(timer);

            Console.WriteLine($"Timer stopped for Task ID {taskId}. Total time added: {timer.ElapsedTime}");
        }

        public void ResumeTimer(int taskId)
        {
            var timer = _timers.FirstOrDefault(t => t.TaskId == taskId);
            if (timer == null)
            {
                Console.WriteLine($"No timer found for Task ID {taskId}");
                return;
            }
            if (!timer.IsPaused)
            {
                Console.WriteLine($"Timer is already running for Task ID {taskId}");
                return;
            }

            timer.StartTime = DateTime.Now;
            timer.IsPaused = false;
            Console.WriteLine($"Timer resumed for Task ID {taskId}");
        }

        public TimeSpan GetElapsedTime(int taskId)
        {
            var timer = _timers.FirstOrDefault(t => t.TaskId == taskId);
            if (timer == null) return TimeSpan.Zero;

            if (!timer.IsPaused && timer.StartTime.HasValue)
            {
                return timer.ElapsedTime + (DateTime.Now - timer.StartTime.Value);
            }
            else
            {
                return timer.ElapsedTime;
            }
        }

        public List<TimerModel> GetAllTimers() => _timers;
    }
}
