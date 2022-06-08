using System.Text;
using cnpmnc.backend.DTOs.AssignmentGradeDTOs;
using cnpmnc.shared;
using cnpmnc.shared.Constants;
using cnpmnc.shared.Enums;
using Newtonsoft.Json;

namespace cnpmnc.frontend.Service

{
    public class AssignmentGradeService : IAssignmentGradeService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public AssignmentGradeService(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<PagedResponseModel<AssignmentGradeDTO>> GetByPageAsync(AssignmentGradeQueryCriteria queryCriteria, CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var data = await client.GetAsync(
                $"/api/assignmentGrades/paging?Page={queryCriteria.Page}" +
                $"&limit={queryCriteria.Limit}" +
                $"&sortColumn={queryCriteria.SortColumn}" +
                $"&sortOrder={queryCriteria.SortOrder}" +
                $"&search={queryCriteria.Search}");
            var body = await data.Content.ReadAsStringAsync();
            var assignmentGrades = JsonConvert.DeserializeObject<PagedResponseModel<AssignmentGradeDTO>>(body);
            return assignmentGrades;
        }
        public async Task<AssignmentGradeDTO> CreateOrUpdate(AssignmentGradeCreateOrUpdateDTO request, int id = 0)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = id == 0 ? await client.PostAsync($"/api/assignmentGrades/", httpContent)
                                    : await client.PutAsync($"/api/assignmentGrades/{id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<AssignmentGradeDTO>(result);

            return JsonConvert.DeserializeObject<AssignmentGradeDTO>(result);
        }

        public async Task<bool> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);

            var response = await client.DeleteAsync($"/api/assignmentGrades/{id}");
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<bool>(result);

            return JsonConvert.DeserializeObject<bool>(result);
        }

        public async Task<AssignmentGradeDTO> GetById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);

            var response = await client.GetAsync($"/api/assignmentGrades/{id}");
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<AssignmentGradeDTO>(result);

            return null;
        }
        public async Task<PagedResponseModel<AssignmentGradeDTO>> GetByPageByIdAsync(int id, AssignmentGradeQueryCriteria queryCriteria, CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var data = await client.GetAsync(
                $"/api/assignmentGrades/paging/{id}?Page={queryCriteria.Page}" +
                $"&limit={queryCriteria.Limit}" +
                $"&sortColumn={queryCriteria.SortColumn}" +
                $"&sortOrder={queryCriteria.SortOrder}" +
                $"&search={queryCriteria.Search}");
            var body = await data.Content.ReadAsStringAsync();
            var assignmentGrades = JsonConvert.DeserializeObject<PagedResponseModel<AssignmentGradeDTO>>(body);
            return assignmentGrades;
        }

        public async Task<AssignmentGradeDTO> RespondToAssignmentGrade(int userId, int assignmentGradeId, AssignmentGradeResponseEnumDto request)
        {

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var json = JsonConvert.SerializeObject(new
            {
                assignmentGradeID = assignmentGradeId,
                response = request
            });
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/assignmentGrades/respond?userId={userId}", httpContent);
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<AssignmentGradeDTO>(result);

            return JsonConvert.DeserializeObject<AssignmentGradeDTO>(result);
        }
    }
}