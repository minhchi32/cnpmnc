using cnpmnc.backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace cnpmnc.backend.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{

    private readonly ICourseService courseService;

    public CourseController(ICourseService courseService)
    {
        this.courseService = courseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await courseService.GetAll());
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
        }
    }
}
