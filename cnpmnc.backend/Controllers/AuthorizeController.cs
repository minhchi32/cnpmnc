using AutoMapper;
using cnpmnc.backend.DTOs.AuthorizeDTOs;
using cnpmnc.backend.Models;
using cnpmnc.shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Validators;

namespace cnpmnc.backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorizeController : ControllerBase
{

    private readonly IBaseRepository<Account> _accountRepository;
    private readonly IMapper _mapper;
    public AuthorizeController(
        IBaseRepository<Account> accountRepository,
        IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<UserLoginResponseDTO> Login([FromBody] UserLoginDTO dto)
    {
        var validationResult = new UserLoginDTOValidator().Validate(dto);
        if (!validationResult.IsValid)
        {
            var error = "Username and password is required.";
            return new UserLoginResponseDTO
            {
                Error = true,
                Message = error,
            };
        }
        var account = _accountRepository.Entities
                        .FirstOrDefault(x => x.Username == dto.Username && x.Password == dto.Password);
        if (account == null)
        {
            var error = "Username or password is incorrect. Please try again";
            return new UserLoginResponseDTO
            {
                Error = true,
                Message = error,
            };
        }
        var roles = account.AccountType;

        UserLoginResponseDTO result = new UserLoginResponseDTO()
        {
            Id = account.Id,
            Name = account.Name,
            Username = account.Username,
            Password = account.Password,
            AccountType = account.AccountType,
            IdCard = account.IdCard,
            PhoneNumber = account.PhoneNumber,
            LiteracyId = account.LiteracyId,
            Status = account.Status,
            Error = false,
            Message = "",
        };
        return result;

    }
}
