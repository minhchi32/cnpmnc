using cnpmnc.backend.DTOs.CourseDTOs;
using cnpmnc.frontend.Service;
using Microsoft.AspNetCore.Mvc;

namespace cnpmnc.frontend.Controllers;

public class CourseController : Controller
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }
    public async Task<IActionResult> Index(string keyword, int page = 1, int limit = 5)
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction("Index", "Authorize");
        }
        else
        {
            var request = new CourseQueryCriteria()
            {
                Search = keyword,
                Limit = limit,
                Page = page
            };
            var data = await _courseService.GetByPageAsync(request, new CancellationToken());
            ViewBag.Keyword = keyword;


            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            HttpContext.Session.GetString("User");
            return View(data);
        }
    }

    [HttpGet]
    public async Task<IActionResult> CreateOrUpdate(int? id)
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction("Index", "Authorize");
        }
        else
        {
            ViewBag.PageName = (id == null ? "Create" : "Edit") + " Course";
            ViewBag.IsEdit = id == null ? false : true;
            if (id == null)
            {
                return View();
            }
            else
            {
                var course = await _courseService.GetById((int)id);

                if (course == null)
                {
                    return NotFound();
                }
                CourseCreateOrUpdateDTO courseCreateOrUpdateDTO = new CourseCreateOrUpdateDTO()
                {
                    Id = course.Id,
                    Name = course.Name,
                    Content = course.Content,
                    Detail = course.Detail,
                    StudyConditions = course.StudyConditions,
                    Tuition = course.Tuition,
                };
                return View(courseCreateOrUpdateDTO);
            }
        }
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateOrUpdate(int id, [FromForm] CourseCreateOrUpdateDTO request)
    {
        ViewBag.PageName = (id == null ? "Create" : "Edit") + " Course";
        ViewBag.IsEdit = id == null ? false : true;
        bool IsCourseExist = false;
        CourseDTO course = await _courseService.GetById(id);

        if (course != null)
        {
            IsCourseExist = true;
        }
        else
        {
            course = new CourseDTO();
        }

        if (!ModelState.IsValid)
            return View(request);
        var result = IsCourseExist ? await _courseService.CreateOrUpdate(request, request.Id)
                                    : await _courseService.CreateOrUpdate(request);
        if (result != null)
        {
            TempData["result"] = IsCourseExist ? "Cập nhật khóa học thành công" : "Thêm mới khóa học thành công";
            return RedirectToAction("Index");
        }

        ModelState.AddModelError("", IsCourseExist ? "Cập nhật khóa học thất bại" : "Thêm mới khóa học thất bại");
        return View(request);
    }
    public async Task<IActionResult> Details(int id)
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction("Index", "Authorize");
        }
        else
        {
            var course = await _courseService.GetById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction("Index", "Authorize");
        }
        else
        {
            var course = await _courseService.GetById((int)id);

            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var result = await _courseService.Delete(id);
        if (result)
        {
            TempData["result"] = "Xóa khóa học thành công";
            return RedirectToAction("Index");
        }

        ModelState.AddModelError("", "Xóa không thành công");
        return View(result);
    }
}

