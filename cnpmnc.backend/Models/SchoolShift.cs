namespace cnpmnc.backend.Models
{
    public class SchoolShift
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}