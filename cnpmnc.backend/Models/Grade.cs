namespace cnpmnc.backend.Models;

public class Grade
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public int NumberOfSessions { get; set; }
    public int Total { get; set; }
    public List<Schedule> Schedules { get; set; }
}