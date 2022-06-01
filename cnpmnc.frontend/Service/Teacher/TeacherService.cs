using System.Text;
using cnpmnc.backend.DTOs.TeacherDTOs;
using cnpmnc.shared;
using cnpmnc.shared.Constants;
using Newtonsoft.Json;

namespace cnpmnc.frontend.Service

{
    public class TeacherService : ITeacherService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public TeacherService(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<PagedResponseModel<TeacherDTO>> GetByPageAsync(TeacherQueryCriteria queryCriteria, CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var data = await client.GetAsync(
                $"/api/teachers/paging?Page={queryCriteria.Page}" +
                $"&limit={queryCriteria.Limit}" +
                $"&sortColumn={queryCriteria.SortColumn}" +
                $"&sortOrder={queryCriteria.SortOrder}" +
                $"&search={queryCriteria.Search}");
            var body = await data.Content.ReadAsStringAsync();
            var teachers = JsonConvert.DeserializeObject<PagedResponseModel<TeacherDTO>>(body);
            return teachers;
        }
        public async Task<TeacherDTO> CreateOrUpdate(TeacherCreateOrUpdateDTO request, int id = 0)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = id == 0 ? await client.PostAsync($"/api/teachers/", httpContent)
                                    : await client.PutAsync($"/api/teachers/{id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<TeacherDTO>(result);

            return JsonConvert.DeserializeObject<TeacherDTO>(result);
        }

        public async Task<bool> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);

            var response = await client.DeleteAsync($"/api/teachers/{id}");
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<bool>(result);

            return JsonConvert.DeserializeObject<bool>(result);
        }

        public async Task<TeacherDTO> GetById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);

            var response = await client.GetAsync($"/api/teachers/{id}");
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<TeacherDTO>(result);

            return null;
        }

        public async Task<List<TeacherDTO>> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var data = await client.GetAsync(
                $"/api/teachers");
            var body = await data.Content.ReadAsStringAsync();
            var teachers = JsonConvert.DeserializeObject<List<TeacherDTO>>(body);
            return teachers;
        }
    }
}