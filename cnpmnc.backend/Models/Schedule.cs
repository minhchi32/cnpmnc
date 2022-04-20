namespace cnpmnc.backend.Models;

public class Schedule
{
    public int Id { get; set; }
    public int GradeId { get; set; }
    public Grade Grade { get; set; }
    public int ClassroomId { get; set; }
    public Classroom Classroom { get; set; }
    public int SchoolShiftId { get; set; }
    public SchoolShift SchoolShift { get; set; }
}