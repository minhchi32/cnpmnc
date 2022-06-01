using cnpmnc.backend.Models;
using cnpmnc.shared;

namespace cnpmnc.frontend.Service
{
    public interface ILiteracyService
    {
        Task<List<Literacy>> GetAll();
    }
}