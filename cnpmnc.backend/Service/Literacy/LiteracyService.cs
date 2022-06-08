using AutoMapper;
using cnpmnc.backend.Models;
using cnpmnc.shared.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace cnpmnc.backend.Service;

class LiteracyService : ILiteracyService
{

    private readonly IBaseRepository<Literacy> _literacyRepository;
    private readonly IMapper _mapper;
    public LiteracyService(
        IBaseRepository<Literacy> literacyRepository,
        IMapper mapper)
    {
        _literacyRepository = literacyRepository;
        _mapper = mapper;
    }
    
    public Task<List<Literacy>> GetAll()
    {
        return _literacyRepository.Entities.ToListAsync();
    }
}