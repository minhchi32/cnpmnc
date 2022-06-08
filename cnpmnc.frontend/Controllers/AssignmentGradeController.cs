using cnpmnc.backend.DTOs.AssignmentGradeDTOs;
using cnpmnc.frontend.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace cnpmnc.frontend.Controllers;

public class AssignmentGradeController : Controller
{
    private readonly IAssignmentGradeService _assignmentGradeService;
    private readonly ITeacherService _teacherService;
    private readonly ICourseService _courseService;

    public AssignmentGradeController(
        IAssignmentGradeService assignmentGradeService,
        ITeacherService teacherService,
        ICourseService courseService)
    {
        _assignmentGradeService = assignmentGradeService;
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
            var request = new AssignmentGradeQueryCriteria()
            {
                Search = keyword,
                Limit = limit,
                Page = page
            };
            var data = await _assignmentGradeService.GetByPageAsync(request, new CancellationToken());
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
        var listCourse = (await _courseService.GetAll());
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
            ViewBag.PageName = (id == null ? "Create" : "Edit") + " AssignmentGrade";
            ViewBag.IsEdit = id == null ? false : true;
            if (id == null)
            {
                return View();
            }
            else
            {
                var assignmentGrade = await _assignmentGradeService.GetById((int)id);

                if (assignmentGrade == null)
                {
                    return NotFound();
                }
                AssignmentGradeCreateOrUpdateDTO assignmentGradeCreateOrUpdateDTO = new AssignmentGradeCreateOrUpdateDTO()
                {
                    Id = assignmentGrade.Id,
                    CourseId = assignmentGrade.CourseId,
                    AssignToTeacherId = assignmentGrade.AssignToTeacherId,
                    Note = assignmentGrade.Note,
                };
                return View(assignmentGradeCreateOrUpdateDTO);
            }
        }
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateOrUpdate(int id, [FromForm] AssignmentGradeCreateOrUpdateDTO request)
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
        ViewBag.PageName = (id == null ? "Create" : "Edit") + " AssignmentGrade";
        ViewBag.IsEdit = id == null ? false : true;
        bool IsAssignmentGradeExist = false;
        AssignmentGradeDTO assignmentGrade = await _assignmentGradeService.GetById(id);

        if (assignmentGrade != null)
        {
            IsAssignmentGradeExist = true;
        }
        else
        {
            assignmentGrade = new AssignmentGradeDTO();
        }

        if (!ModelState.IsValid)
            return View(request);
        var result = IsAssignmentGradeExist ? await _assignmentGradeService.CreateOrUpdate(request, request.Id)
                                    : await _assignmentGradeService.CreateOrUpdate(request);
        if (result != null)
        {
            TempData["result"] = IsAssignmentGradeExist ? "Cập nhật thành công" : "Thêm mới thành công";
            return RedirectToAction("Index");
        }

        ModelState.AddModelError("", IsAssignmentGradeExist ? "Cập nhật thất bại" : "Thêm mới thất bại");
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
            var assignmentGrade = await _assignmentGradeService.GetById(id);
            if (assignmentGrade == null)
            {
                return NotFound();
            }
            return View(assignmentGrade);
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
            var assignmentGrade = await _assignmentGradeService.GetById((int)id);

            if (assignmentGrade == null)
            {
                return NotFound();
            }
            return View(assignmentGrade);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var result = await _assignmentGradeService.Delete(id);
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

