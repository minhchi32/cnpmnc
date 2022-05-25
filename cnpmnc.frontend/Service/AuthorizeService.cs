using System.Text;
using cnpmnc.backend.DTOs.AuthorizeDTOs;
using cnpmnc.backend.DTOs.CourseDTOs;
using cnpmnc.shared;
using cnpmnc.shared.Constants;
using Newtonsoft.Json;

namespace cnpmnc.frontend.Service

{
    public class AuthorizeService : IAuthorizeService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public AuthorizeService(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UserLoginResponseDTO> Login(UserLoginDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var json = JsonConvert.SerializeObject(dto);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/authorize/", httpContent);

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<UserLoginResponseDTO>(result);

            return JsonConvert.DeserializeObject<UserLoginResponseDTO>(result);
        }

    }
}