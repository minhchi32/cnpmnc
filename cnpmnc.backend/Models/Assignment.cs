using cnpmnc.shared.Enums;

namespace cnpmnc.backend.Models;

public class Assignment
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public int AssignToTeacherId { get; set; }
    public Account Teacher { get; set; }
    public AssignmentStateEnumDto State { get; set; }
    public string Note { get; set; }
    public DateTime AssignDate { get; set; }
    public bool IsDeleted { get; set; }
}