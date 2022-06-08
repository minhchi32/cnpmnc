using cnpmnc.shared.Enums;

namespace cnpmnc.backend.Models;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public AccountType AccountType { get; set; }
    public string Address { get; set; }
    public string IdCard { get; set; }
    public int PhoneNumber { get; set; }
    public int LiteracyId { get; set; }
    public Literacy Literacy { get; set; }
    public AccountStatusEnumDto Status { get; set; }
    public List<AssignmentGrade>? AssignmentGrades { get; set; }
}