using cnpmnc.shared.Enums;

namespace cnpmnc.backend.Models;

public class AssignmentGrade
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public int AssignToTeacherId { get; set; }
    public Account Teacher { get; set; }
    public string Note { get; set; }
    public AssignmentGradeStateEnumDto State { get; set; }
    public int Total { get; set; }
    public DateTime AssignDate { get; set; }
    public SemesterEnumDto Semester { get; set; }
    public List<Schedule> Schedules { get; set; }
}