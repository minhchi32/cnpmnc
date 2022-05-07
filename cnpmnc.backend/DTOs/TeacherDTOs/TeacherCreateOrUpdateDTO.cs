using cnpmnc.backend.Models;

namespace cnpmnc.backend.DTOs.TeacherDTOs;

public class TeacherCreateOrUpdateDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string IdCard { get; set; }
    public int PhoneNumber { get; set; }
    public int LiteracyId { get; set; }
}