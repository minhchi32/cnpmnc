using cnpmnc.backend.DTOs.AssignmentDTOs;
using cnpmnc.frontend.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace cnpmnc.frontend.Controllers;

public class AssignmentController : Controller
{
    private readonly IAssignmentService _assignmentService;
    private readonly ITeacherService _teacherService;
    private readonly ICourseService _courseService;

    public AssignmentController(
        IAssignmentService assignmentService,
        ITeacherService teacherService,
        ICourseService courseService)
    {
        _assignmentService = assignmentService;
        _teacherService = teacherService;
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
            var request = new AssignmentQueryCriteria()
            {
                Search = keyword,
                Limit = limit,
                Page = page
            };
            var data = await _assignmentService.GetByPageAsync(request, new CancellationToken());
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
        var listCourse = await _courseService.GetAll();
        var courses = new List<SelectListItem>();
        foreach (var item in listCourse)
        {
            courses.Add(new SelectListItem()
            {
                Text = item.Name,
                Value = item.Id.ToString()
            });
        }
        ViewBag.Course = courses;

        var listTeacher = await _teacherService.GetAll();
        var teachers = new List<SelectListItem>();
        foreach (var item in listTeacher)
        {
            teachers.Add(new SelectListItem()
            {
                Text = item.Name,
                Value = item.Id.ToString()
            });
        }
        ViewBag.Teacher = teachers;
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction("Index", "Authorize");
        }
        else
        {
            ViewBag.PageName = (id == null ? "Create" : "Edit") + " Assignment";
            ViewBag.IsEdit = id == null ? false : true;
            if (id == null)
            {
                return View();
            }
            else
            {
                var assignment = await _assignmentService.GetById((int)id);

                if (assignment == null)
                {
                    return NotFound();
                }
                AssignmentCreateOrUpdateDTO assignmentCreateOrUpdateDTO = new AssignmentCreateOrUpdateDTO()
                {
                    Id = assignment.Id,
                    CourseId = assignment.CourseId,
                    AssignToTeacherId = assignment.AssignToTeacherId,
                    AssignDate = assignment.AssignDate,
                    Note = assignment.Note,
                };
                return View(assignmentCreateOrUpdateDTO);
            }
        }
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateOrUpdate(int id, [FromForm] AssignmentCreateOrUpdateDTO request)
    {
        var listCourse = await _courseService.GetAll();
        var courses = new List<SelectListItem>();
        foreach (var item in listCourse)
        {
            courses.Add(new SelectListItem()
            {
                Text = item.Name,
                Value = item.Id.ToString()
            });
        }
        ViewBag.Course = courses;

        var listTeacher = await _teacherService.GetAll();
        var teachers = new List<SelectListItem>();
        foreach (var item in listTeacher)
        {
            teachers.Add(new SelectListItem()
            {
                Text = item.Name,
                Value = item.Id.ToString()
            });
        }
        ViewBag.Teacher = teachers;
        ViewBag.PageName = (id == null ? "Create" : "Edit") + " Assignment";
        ViewBag.IsEdit = id == null ? false : true;
        bool IsAssignmentExist = false;
        AssignmentDTO assignment = await _assignmentService.GetById(id);

        if (assignment != null)
        {
            IsAssignmentExist = true;
        }
        else
        {
            assignment = new AssignmentDTO();
        }

        if (!ModelState.IsValid)
            return View(request);
        var result = IsAssignmentExist ? await _assignmentService.CreateOrUpdate(request, request.Id)
                                    : await _assignmentService.CreateOrUpdate(request);
        if (result != null)
        {
            TempData["result"] = IsAssignmentExist ? "Cập nhật thành công" : "Thêm mới thành công";
            return RedirectToAction("Index");
        }

        ModelState.AddModelError("", IsAssignmentExist ? "Cập nhật thất bại" : "Thêm mới thất bại");
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
            var assignment = await _assignmentService.GetById(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
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
            var assignment = await _assignmentService.GetById((int)id);

            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var result = await _assignmentService.Delete(id);
        if (result)
        {
            TempData["result"] = "Xóa thành công";
            return RedirectToAction("Index");
        }

        ModelState.AddModelError("", "Xóa không thành công");
        return View(result);
    }

    async void GetViewBag()
    {
        var listCourse = await _courseService.GetAll();
        var courses = new List<SelectListItem>();
        foreach (var item in listCourse)
        {
            courses.Add(new SelectListItem()
            {
                Text = item.Name,
                Value = item.Id.ToString()
            });
        }
        ViewBag.Course = courses;

        var listTeacher = await _teacherService.GetAll();
        var teachers = new List<SelectListItem>();
        foreach (var item in listTeacher)
        {
            teachers.Add(new SelectListItem()
            {
                Text = item.Name,
                Value = item.Id.ToString()
            });
        }
        ViewBag.Teacher = teachers;
    }
}

