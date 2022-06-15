using cnpmnc.backend.DTOs.AssignmentGradeDTOs;
using cnpmnc.backend.DTOs.TeacherDTOs;
using cnpmnc.frontend.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace cnpmnc.frontend.Controllers;

public class TeacherController : Controller
{
    private readonly ITeacherService _teacherService;
    private readonly ILiteracyService _literacyService;
    private readonly IAssignmentGradeService _assignmentGradeService;

    public TeacherController(
        ITeacherService teacherService,
        ILiteracyService literacyService,
        IAssignmentGradeService assignmentGradeService)
    {
        _teacherService = teacherService;
        _literacyService = literacyService;
        _assignmentGradeService = assignmentGradeService;
    }
    public async Task<IActionResult> Index(string keyword, int page = 1, int limit = 5)
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction("Index", "Authorize");
        }
        else
        {
            var request = new TeacherQueryCriteria()
            {
                Search = keyword,
                Limit = limit,
                Page = page
            };
            var data = await _teacherService.GetByPageAsync(request, new CancellationToken());
            ViewBag.Keyword = keyword;


            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
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
            ViewBag.PageName = (id == null ? "Create" : "Edit") + " Teacher";
            ViewBag.IsEdit = id == null ? false : true;

            var listLiteracy = await _literacyService.GetAll();
            var literacies = new List<SelectListItem>();
            foreach (var item in listLiteracy)
            {
                literacies.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.Literacy = literacies;
            ViewBag.Username = "abc";
            if (id == null)
            {
                return View();
            }
            else
            {
                var teacher = await _teacherService.GetById((int)id);

                if (teacher == null)
                {
                    return NotFound();
                }
                TeacherCreateOrUpdateDTO teacherCreateOrUpdateDTO = new TeacherCreateOrUpdateDTO()
                {
                    Id = teacher.Id,
                    Username = teacher.Username,
                    Name = teacher.Name,
                    IdCard = teacher.IdCard,
                    Address = teacher.Address,
                    PhoneNumber = teacher.PhoneNumber,
                    LiteracyId = teacher.LiteracyId,
                };
                return View(teacherCreateOrUpdateDTO);
            }
        }
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateOrUpdate(int id, [FromForm] TeacherCreateOrUpdateDTO request)
    {
        ViewBag.PageName = (id == null ? "Create" : "Edit") + " Course";
        ViewBag.IsEdit = id == null ? false : true;
        bool IsTeacherExist = false;
        TeacherDTO teacher = await _teacherService.GetById(id);
        ViewBag.Username = "abc";
        if (teacher != null)
        {
            IsTeacherExist = true;
        }
        else
        {
            teacher = new TeacherDTO();
        }
        //request.Username = "";
        if (!ModelState.IsValid)
            return View(request);
        var result = IsTeacherExist ? await _teacherService.CreateOrUpdate(request, request.Id)
                                    : await _teacherService.CreateOrUpdate(request);
        if (result != null)
        {
            TempData["result"] = IsTeacherExist ? "Cập nhật giảng viên thành công" : "Thêm mới giảng viên thành công";
            return RedirectToAction("Index");
        }

        ModelState.AddModelError("", IsTeacherExist ? "Cập nhật giảng viên thất bại" : "Thêm mới giảng viên thất bại");
        return View(request);
    }
    public async Task<IActionResult> Details(int id, string keyword, int page = 1, int limit = 5)
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction("Index", "Authorize");
        }
        else
        {
            var teacher = await _teacherService.GetById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            ViewBag.teacher = teacher;
            // return View(teacher);

            var request = new AssignmentGradeQueryCriteria()
            {
                Search = keyword,
                Limit = limit,
                Page = page
            };
            var data = await _assignmentGradeService.GetByPageByIdAsync(id, request, new CancellationToken());
            ViewBag.Keyword = keyword;


            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data);
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
            var teacher = await _teacherService.GetById((int)id);

            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        if (!ModelState.IsValid)
            return View();

        var result = await _teacherService.Delete(id);
        if (result)
        {
            TempData["result"] = "Xóa giảng viên thành công";
            return RedirectToAction("Index");
        }

        ModelState.AddModelError("", "Xóa không thành công");
        return View(result);
    }
}

