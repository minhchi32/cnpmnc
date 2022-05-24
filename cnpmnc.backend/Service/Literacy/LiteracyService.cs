using AutoMapper;
using cnpmnc.backend.DTOs.GradeDTOs;
using cnpmnc.backend.Extensions;
using cnpmnc.backend.Models;
using cnpmnc.shared;
using cnpmnc.shared.Enums;
using cnpmnc.shared.Exceptions;
using cnpmnc.shared.Interfaces;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
namespace cnpmnc.backend.Service;

class LiteracyService : ILiteracyService
{

    private readonly IBaseRepository<Literacy> _literacyRepository;
    private readonly IMapper _mapper;
    public LiteracyService(
        IBaseRepository<Literacy> litegaryRepository,
        IMapper mapper)
    {
        _literacyRepository = litegaryRepository;
        _mapper = mapper;
    }
    
    public Task<List<Literacy>> GetAll()
    {
        return _literacyRepository.Entities.ToListAsync();
    }
}