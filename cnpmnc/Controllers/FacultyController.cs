using cnpmnc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace cnpmnc.Controllers
{
    public class FacultyController : Controller
    {
        QLSVContext _context = new QLSVContext();
        public IActionResult Index()
        {
            var list = _context.Faculties.AsAsyncEnumerable();
            return View(list);
        }
        //AddOrEdit Get Method
        public async Task<IActionResult> AddOrEdit(int? id)
        {
            ViewBag.PageName = id == null ? "Create Faculty" : "Edit Faculty";
            ViewBag.IsEdit = id == null ? false : true;
            if (id == null)
            {
                return View();
            }
            else
            {
                var faculty = await _context.Faculties.FindAsync(id);

                if (faculty == null)
                {
                    return NotFound();
                }
                return View(faculty);
            }
        }

        //AddOrEdit Post Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("ID,Name")]Faculty facultyData)
        {
            bool IsFacultyExist = false;

            Faculty faculty = await _context.Faculties.FindAsync(id);

            if (faculty != null)
            {
                IsFacultyExist = true;
            }
            else
            {
                faculty = new Faculty();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    faculty.Name = facultyData.Name;

                    if (IsFacultyExist)
                    {
                        _context.Update(faculty);
                    }
                    else
                    {
                        _context.Add(faculty);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(facultyData);
        }
        // Employee Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var faculty = await _context.Faculties.FirstOrDefaultAsync(m => m.Id == id);
            if (faculty == null)
            {
                return NotFound();
            }
            return View(faculty);
        }
        // GET: Employees/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var faculty = await _context.Faculties.FirstOrDefaultAsync(m => m.Id == id);

            return View(faculty);
        }

        // POST: Employees/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var faculty = await _context.Faculties.FindAsync(id);
            _context.Faculties.Remove(faculty);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
