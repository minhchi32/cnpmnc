using System.Text;
using cnpmnc.backend.DTOs.CourseDTOs;
using cnpmnc.shared;
using cnpmnc.shared.Constants;
using Newtonsoft.Json;

namespace cnpmnc.frontend.Service

{
    public class CourseService : ICourseService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public CourseService(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<PagedResponseModel<CourseDTO>> GetByPageAsync(CourseQueryCriteria queryCriteria, CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var data = await client.GetAsync(
                $"/api/courses/paging?Page={queryCriteria.Page}" +
                $"&limit={queryCriteria.Limit}" +
                $"&sortColumn={queryCriteria.SortColumn}" +
                $"&sortOrder={queryCriteria.SortOrder}" +
                $"&search={queryCriteria.Search}");
            var body = await data.Content.ReadAsStringAsync();
            var courses = JsonConvert.DeserializeObject<PagedResponseModel<CourseDTO>>(body);
            return courses;
        }
        public async Task<CourseDTO> CreateOrUpdate(CourseCreateOrUpdateDTO request, int id = 0)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = id == 0 ? await client.PostAsync($"/api/courses/", httpContent)
                                    : await client.PutAsync($"/api/courses/{id}", httpContent);
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<CourseDTO>(result);

            return JsonConvert.DeserializeObject<CourseDTO>(result);
        }

        public async Task<bool> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);

            var response = await client.DeleteAsync($"/api/courses/{id}");
            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<bool>(result);

            return JsonConvert.DeserializeObject<bool>(result);
        }

        public async Task<CourseDTO> GetById(int id)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);

            var response = await client.GetAsync($"/api/courses/{id}");
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<CourseDTO>(result);

            return null;
        }

        public async Task<List<CourseDTO>> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var data = await client.GetAsync(
                $"/api/courses");
            var body = await data.Content.ReadAsStringAsync();
            var courses = JsonConvert.DeserializeObject<List<CourseDTO>>(body);
            return courses;
        }
    }
}