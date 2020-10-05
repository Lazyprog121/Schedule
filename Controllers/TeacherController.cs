using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KPI_Schedule.Models;

namespace KPI_Schedule.Controllers
{
    public class TeacherController : Controller
    {
        public DbSchedule Context { get; }
        public TeacherController(DbSchedule context) => Context = context;

        public async Task<IActionResult> List()
        {
            return View(await Context.Teachers.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                Context.Add(teacher);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View(teacher);
        }

        public async Task<IActionResult> Choose(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Teachers.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Teachers.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                Context.Update(teacher);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View(teacher);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Teachers.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Context.Teachers.Remove(await Context.Teachers.FindAsync(id));
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
