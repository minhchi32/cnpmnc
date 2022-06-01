using System.Text;
using cnpmnc.backend.DTOs.GradeDTOs;
using cnpmnc.shared;
using cnpmnc.shared.Constants;
using Newtonsoft.Json;

namespace cnpmnc.frontend.Service

{
    public class GradeService : IGradeService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public GradeService(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<PagedResponseModel<GradeDTO>> GetByPageByIdAsync(int id, GradeQueryCriteria queryCriteria, CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var data = await client.GetAsync(
                $"/api/grades/paging/{id}?Page={queryCriteria.Page}" +
                $"&limit={queryCriteria.Limit}" +
                $"&sortColumn={queryCriteria.SortColumn}" +
                $"&sortOrder={queryCriteria.SortOrder}" +
                $"&search={queryCriteria.Search}");
            var body = await data.Content.ReadAsStringAsync();
            var grades = JsonConvert.DeserializeObject<PagedResponseModel<GradeDTO>>(body);
            return grades;
        }

        public async Task<PagedResponseModel<GradeDTO>> GetByPageAsync(GradeQueryCriteria queryCriteria, CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var data = await client.GetAsync(
                $"/api/grades/paging/?Page={queryCriteria.Page}" +
                $"&limit={queryCriteria.Limit}" +
                $"&sortColumn={queryCriteria.SortColumn}" +
                $"&sortOrder={queryCriteria.SortOrder}" +
                $"&search={queryCriteria.Search}");
            var body = await data.Content.ReadAsStringAsync();
            var grades = JsonConvert.DeserializeObject<PagedResponseModel<GradeDTO>>(body);
            return grades;
        }
    }
}