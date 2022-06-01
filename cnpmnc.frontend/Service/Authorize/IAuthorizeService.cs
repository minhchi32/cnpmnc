using cnpmnc.backend.DTOs.AuthorizeDTOs;
using cnpmnc.backend.DTOs.CourseDTOs;
using cnpmnc.shared;

namespace cnpmnc.frontend.Service
{
    public interface IAuthorizeService
    {
        public Task<UserLoginResponseDTO> Login(UserLoginDTO dto);
    }
}