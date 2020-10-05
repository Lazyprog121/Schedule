using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KPI_Schedule.Models;

namespace KPI_Schedule.Controllers
{
    public class DisciplineController : Controller
    {
        public DbSchedule Context { get; }
        public DisciplineController(DbSchedule context) => Context = context;

        public async Task<IActionResult> List()
        {
            return View(await Context.Disciplines.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Discipline discipline)
        {
            if (ModelState.IsValid)
            {
                Context.Add(discipline);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View(discipline);
        }

        public async Task<IActionResult> Choose(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Disciplines.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Disciplines.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Discipline discipline)
        {
            if (ModelState.IsValid)
            {
                Context.Update(discipline);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View(discipline);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Disciplines.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Context.Disciplines.Remove(await Context.Disciplines.FindAsync(id));
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
