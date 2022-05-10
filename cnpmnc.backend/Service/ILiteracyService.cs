using cnpmnc.backend.Models;

namespace cnpmnc.backend.Service
{

    public interface ILiteracyService
    {
        Task<List<Literacy>> GetAll();
    }
}