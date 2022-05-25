using cnpmnc.backend.Models;
using cnpmnc.shared.Enums;

namespace cnpmnc.backend.DTOs.AuthorizeDTOs;

public class UserLoginResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public AccountType AccountType { get; set; }
    public string IdCard { get; set; }
    public int PhoneNumber { get; set; }
    public int LiteracyId { get; set; }
    public Literacy Literacy { get; set; }
    public int? NumberOfHoursInClass { get; set; }
    public int? ActualNumberOfHoursInClass { get; set; }
    public int? NumberOfTeachingSessions { get; set; }
    public int? NumberOfBreaks { get; set; }
    public List<Grade>? Grades { get; set; }
    public List<Assignment>? Assignments { get; set; }
    public bool IsDeleted { get; set; }
    public string Token { get; set; }
    public bool Error { get; set; }
    public string Message { get; set; }
}