using cnpmnc.backend.Models;
using cnpmnc.backend.Service;
using cnpmnc.shared;
using Microsoft.AspNetCore.Mvc;

namespace cnpmnc.backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LiteraciesController : ControllerBase
{

    private readonly ILiteracyService _literacyService;

    public LiteraciesController(ILiteracyService literacyService)
    {
        _literacyService = literacyService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Literacy>>> GetLiteracy()
    {
        var responses = await _literacyService.GetAll();
        return Ok(responses);
    }
}
