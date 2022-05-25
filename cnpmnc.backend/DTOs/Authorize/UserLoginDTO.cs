using cnpmnc.backend.Models;

namespace cnpmnc.backend.DTOs.AuthorizeDTOs;

public class UserLoginDTO
{
    public string Username { get; set; }

    public string Password { get; set; }
}