using cnpmnc.Models;
using Microsoft.AspNetCore.Mvc;

namespace cnpmnc.Controllers
{
    public class StudentController : Controller
    {
        QLSVContext db = new QLSVContext();
        public IActionResult Index()
        {
            var list = db.Students.AsQueryable();
            return View(list);
        }
    }
}
