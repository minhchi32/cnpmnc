namespace cnpmnc.backend.Models;

public class Schedule
{
    public int Id { get; set; }
    public int AssignmentGradeId { get; set; }
    public AssignmentGrade AssignmentGrade { get; set; }
    public int ClassroomId { get; set; }
    public Classroom Classroom { get; set; }
    public int SchoolShiftId { get; set; }
    public SchoolShift SchoolShift { get; set; }
    public DateTime StartDate{get;set;}
    public DateTime EndDate { get; set; }
}