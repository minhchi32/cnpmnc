namespace cnpmnc.backend.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Note { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}