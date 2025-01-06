namespace CLI_Task_Timer.Models
{
    public class TimerModel
    {
        public int TaskId { get; set; }
        public DateTime? StartTime { get; set; }
        public bool IsPaused { get; set; }
        public TimeSpan ElapsedTime { get; set; }
    }
}