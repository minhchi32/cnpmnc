namespace cnpmnc.backend.Models;

public class TeacherGrade
{
    public int TeacherId { get; set; }
    public int GradeId { get; set; }
    public Account Teacher{get;set;}
    public Grade Grade { get; set; }
}