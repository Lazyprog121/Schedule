using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KPI_Schedule.Models;

namespace KPI_Schedule.Controllers
{
    public class StudentController : Controller
    {
        public DbSchedule Context { get; }
        public StudentController(DbSchedule context) => Context = context;

        public async Task<IActionResult> List()
        {
            return View(await Context.Students.ToListAsync());
        }

        public IActionResult Create()
        {
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

            var element = await Context.Students.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Students.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

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

            var element = await Context.Students.FirstOrDefaultAsync(e => e.Id == id);

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
