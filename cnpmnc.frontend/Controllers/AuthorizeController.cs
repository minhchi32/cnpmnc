using cnpmnc.backend.DTOs.AuthorizeDTOs;
using cnpmnc.backend.DTOs.CourseDTOs;
using cnpmnc.frontend.Service;
using cnpmnc.shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace cnpmnc.frontend.Controllers;

public class AuthorizeController : Controller
{
    private readonly IAuthorizeService _authorizeService;

    public AuthorizeController(IAuthorizeService authorizeService)
    {
        _authorizeService = authorizeService;
    }
    public ActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(UserLoginDTO user)
    {
        var data = await _authorizeService.Login(user);
        if (data.Error)
        {
            ViewBag.Error = data.Message;
            return View();
        }
        HttpContext.Session.SetString("User", data.AccountType.ToString());
        HttpContext.Session.SetInt32("UserID", data.Id);
        HttpContext.Session.SetString("UserName", data.Name.ToString());
        switch (data.AccountType)
        {
            case AccountType.Admin:
                return RedirectToAction("Index","Course");
            case AccountType.Teacher:
                return RedirectToAction("UpdateInfo","Account");
            default:
                return View();
        }
    }
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index","Authorize");
    }
}

