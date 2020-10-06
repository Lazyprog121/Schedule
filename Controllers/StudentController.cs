using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using KPI_Schedule.Models;

namespace KPI_Schedule.Controllers
{
    public class StudentController : Controller
    {
        public DbSchedule Context { get; }
        public StudentController(DbSchedule context) => Context = context;

        public async Task<IActionResult> List()
        {
            return View(await Context.Students.Include(n => n.Group).ToListAsync());
        }

        public IActionResult Create()
        {
            List<Group> list = new List<Group>();
            foreach (Group item in Context.Groups)
                list.Add(item);

            ViewBag.GroupId = new SelectList(list, "Id", "Name", list[0]);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                Context.Add(student);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View(student);
        }

        public async Task<IActionResult> Choose(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Students.Include(n => n.Group).FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Students.Include(n => n.Group).FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            List<Group> list = new List<Group>();
            foreach (Group item in Context.Groups)
                list.Add(item);

            ViewBag.GroupId = new SelectList(list, "Id", "Name", element.GroupId);

            return View(element);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                Context.Update(student);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View(student);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Students.Include(n => n.Group).FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Context.Students.Remove(await Context.Students.FindAsync(id));
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
