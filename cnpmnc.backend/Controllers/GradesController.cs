using cnpmnc.backend.DTOs.GradeDTOs;
using cnpmnc.backend.Service;
using cnpmnc.shared;
using EnsureThat;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Validators;

namespace cnpmnc.backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradesController : ControllerBase
{

    private readonly IGradeService _gradeService;

    public GradesController(IGradeService gradeService)
    {
        _gradeService = gradeService;
    }

    [HttpGet("paging")]
    public async Task<ActionResult<PagedResponseModel<GradeDTO>>> GetGrades(
        int id,
        [FromQuery] GradeQueryCriteria criteria,
        CancellationToken cancellationToken)
    {

        var responses = await _gradeService.GetByPageByTeacherIdAsync(
                                        id,
                                        criteria,
                                        cancellationToken);
        return Ok(responses);
    }

    [HttpGet("paging/{id}")]
    public async Task<ActionResult<PagedResponseModel<GradeDTO>>> GetGradeByTeacherId(int id,
        [FromQuery] GradeQueryCriteria criteria,
        CancellationToken cancellationToken)
    {

        var responses = await _gradeService.GetByPageByTeacherIdAsync(id,
                                        criteria,
                                        cancellationToken);
        return Ok(responses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PagedResponseModel<GradeDTO>>> GetGrade(int id)
    {
        var responses = await _gradeService.GetById(id);
        return Ok(responses);
    }
}
