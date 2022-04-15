using cnpmnc.shared.Enums;

namespace cnpmnc.backend.Models;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public AccountType AccountType { get; set; }
    public string IdCard { get; set; }
    public int PhoneNumber { get; set; }
    public List<Literacy>? Literacies { get; set; }
    public int? NumberOfHoursInClass { get; set; }
    public int? ActualNumberOfHoursInClass { get; set; }
    public int? NumberOfTeachingSessions { get; set; }
    public int? NumberOfBreaks { get; set; }
    public List<TeacherGrade>? TeacherGrades { get; set; }
}