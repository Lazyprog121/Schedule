using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KPI_Schedule.Models;

namespace KPI_Schedule.Controllers
{
    public class FacultyController : Controller
    {
        public DbSchedule Context { get; }
        public FacultyController(DbSchedule context) => Context = context;

        public async Task<IActionResult> List()
        {
            return View(await Context.Faculties.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                Context.Add(faculty);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View(faculty);
        }

        public async Task<IActionResult> Choose(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Faculties.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Faculties.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                Context.Update(faculty);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View(faculty);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Faculties.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Context.Faculties.Remove(await Context.Faculties.FindAsync(id));
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
