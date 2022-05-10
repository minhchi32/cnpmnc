using cnpmnc.backend.Models;
using cnpmnc.shared;
using cnpmnc.shared.Constants;
using Newtonsoft.Json;

namespace cnpmnc.frontend.Service

{
    public class LiteracyService : ILiteracyService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public LiteracyService(
            IHttpClientFactory httpClientFactory,
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<Literacy>> GetAll()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration[ConfigurationConstants.BackendEndPoint]);
            var data = await client.GetAsync(
                $"/api/literacies");
            var body = await data.Content.ReadAsStringAsync();
            var literacies = JsonConvert.DeserializeObject<List<Literacy>>(body);
            return literacies;
        }
    }
}