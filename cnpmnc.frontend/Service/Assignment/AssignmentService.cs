using System.Text;
using cnpmnc.backend.DTOs.AssignmentDTOs;
using cnpmnc.shared;
using cnpmnc.shared.Constants;
using cnpmnc.shared.Enums;
using Newtonsoft.Json;

namespace cnpmnc.frontend.Service

{
    public class AssignmentService : IAssignmentService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public AssignmentService(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<PagedResponseModel<AssignmentDTO>> GetByPageAsync(AssignmentQueryCriteria queryCriteria, CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var data = await client.GetAsync(
                $"/api/assignments/paging?Page={queryCriteria.Page}" +
                $"&limit={queryCriteria.Limit}" +
                $"&sortColumn={queryCriteria.SortColumn}" +
                $"&sortOrder={queryCriteria.SortOrder}" +
                $"&search={queryCriteria.Search}");
            var body = await data.Content.ReadAsStringAsync();
            var assignments = JsonConvert.DeserializeObject<PagedResponseModel<AssignmentDTO>>(body);
            return assignments;
        }
        public async Task<AssignmentDTO> CreateOrUpdate(AssignmentCreateOrUpdateDTO request, int id = 0)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = id == 0 ? await client.PostAsync($"/api/assignments/", httpContent)
                                    : await client.PutAsync($"/api/assignments/{id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<AssignmentDTO>(result);

            return JsonConvert.DeserializeObject<AssignmentDTO>(result);
        }

        public async Task<bool> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);

            var response = await client.DeleteAsync($"/api/assignments/{id}");
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<bool>(result);

            return JsonConvert.DeserializeObject<bool>(result);
        }

        public async Task<AssignmentDTO> GetById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);

            var response = await client.GetAsync($"/api/assignments/{id}");
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<AssignmentDTO>(result);

            return null;
        }
        public async Task<PagedResponseModel<AssignmentDTO>> GetByPageByIdAsync(int id, AssignmentQueryCriteria queryCriteria, CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var data = await client.GetAsync(
                $"/api/assignments/paging/{id}?Page={queryCriteria.Page}" +
                $"&limit={queryCriteria.Limit}" +
                $"&sortColumn={queryCriteria.SortColumn}" +
                $"&sortOrder={queryCriteria.SortOrder}" +
                $"&search={queryCriteria.Search}");
            var body = await data.Content.ReadAsStringAsync();
            var assignments = JsonConvert.DeserializeObject<PagedResponseModel<AssignmentDTO>>(body);
            return assignments;
        }

        public async Task<AssignmentDTO> RespondToAssignment(int userId, int assignmentId, AssignmentResponseEnumDto request)
        {

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var json = JsonConvert.SerializeObject(new
            {
                assignmentID = assignmentId,
                response = request
            });
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/assignments/respond?userId={userId}", httpContent);
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<AssignmentDTO>(result);

            return JsonConvert.DeserializeObject<AssignmentDTO>(result);
        }
    }
}