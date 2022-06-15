using cnpmnc.backend.DTOs.AssignmentGradeDTOs;
using cnpmnc.backend.DTOs.TeacherDTOs;
using cnpmnc.frontend.Service;
using cnpmnc.shared.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace cnpmnc.frontend.Controllers;

public class AccountController : Controller
{
    private readonly ITeacherService _teacherService;
    private readonly ILiteracyService _literacyService;
    private readonly IAssignmentGradeService _assignmentGradeService;

    public AccountController(
        ITeacherService teacherService,
        ILiteracyService literacyService,
        IAssignmentGradeService assignmentGradeService)
    {
        _teacherService = teacherService;
        _literacyService = literacyService;
        _assignmentGradeService = assignmentGradeService;
    }


    [HttpGet]
    public async Task<IActionResult> UpdateInfo()
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction("Index", "Authorize");
        }
        else
        {
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
            var teacher = await _teacherService.GetById((int)HttpContext.Session.GetInt32("UserID"));

            if (teacher == null)
            {
                return NotFound();
            }
            TeacherCreateOrUpdateDTO teacherCreateOrUpdateDTO = new TeacherCreateOrUpdateDTO()
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Username = teacher.Username,
                Address = teacher.Address,
                IdCard = teacher.IdCard,
                PhoneNumber = teacher.PhoneNumber,
                LiteracyId = teacher.LiteracyId,
            };
            ViewBag.Literacy = teacher.Literacy.Name;
            return View(teacherCreateOrUpdateDTO);
        }
    }

    [HttpPost]
    [Consumes("multipart/form-data")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateInfo([FromForm] TeacherCreateOrUpdateDTO request)
    {
        TeacherDTO teacher = await _teacherService.GetById((int)HttpContext.Session.GetInt32("UserID"));
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
        ViewBag.Literacy = teacher.Literacy.Name;
        if (!ModelState.IsValid)
            return View(request);
        var result = await _teacherService.CreateOrUpdate(request, request.Id);
        if (result != null)
        {
            TempData["result"] = "Cập nhật thông tin thành công";
            return RedirectToAction("UpdateInfo");
        }

        ModelState.AddModelError("", "Cập nhật thông tin thất bại");
        return View(request);
    }
    // public async Task<IActionResult> ListAssignmentGrade(string keyword, int page = 1, int limit = 5)
    // {
    //     if (HttpContext.Session.GetString("User") == null)
    //     {
    //         return RedirectToAction("Index", "Authorize");
    //     }
    //     else
    //     {
    //         var request = new GradeQueryCriteria()
    //         {
    //             Search = keyword,
    //             Limit = limit,
    //             Page = page
    //         };
    //         var data = await _assignmentGradeService.GetByPageByIdAsync((int)HttpContext.Session.GetInt32("UserID"), request, new CancellationToken());
    //         ViewBag.Keyword = keyword;

    //         return View(data);
    //     }
    // }
    public async Task<IActionResult> ListAssignmentGrade(string keyword, int page = 1, int limit = 5)
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction("Index", "Authorize");
        }
        else
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            var request = new AssignmentGradeQueryCriteria()
            {
                Search = keyword,
                Limit = limit,
                Page = page
            };
            var data = await _assignmentGradeService.GetByPageByIdAsync((int)HttpContext.Session.GetInt32("UserID"), request, new CancellationToken());
            ViewBag.Keyword = keyword;

            return View(data);
        }
    }
    public async Task<IActionResult> RespondToAssignmentGrade(int assignmentGradeId, AssignmentGradeResponseEnumDto respond)
    {
        if (HttpContext.Session.GetString("User") == null)
        {
            return RedirectToAction("Index", "Authorize");
        }
        else
        {
            string result = respond == AssignmentGradeResponseEnumDto.Accepted ? "Đồng ý" : "Hủy bỏ";
            var data = await _assignmentGradeService.RespondToAssignmentGrade((int)HttpContext.Session.GetInt32("UserID"), assignmentGradeId, respond);
            if (data.State!=AssignmentGradeStateEnumDto.WaitingForAcceptance)
            {
                TempData["result"] = $"{result} thành công";
                return RedirectToAction("ListAssignmentGrade");
            }

            ModelState.AddModelError("", $"{result} thất bại");
            return RedirectToAction("ListAssignmentGrade");
        }
    }

}

