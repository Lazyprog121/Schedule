using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KPI_Schedule.Models;

namespace KPI_Schedules.Controllers
{
    public class SchedulesController : Controller
    {
        public DbSchedule Context { get; }
        public SchedulesController(DbSchedule context) => Context = context;

        public async Task<IActionResult> List()
        {
            return View(await Context.Schedules.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                Context.Add(schedule);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View(schedule);
        }

        public async Task<IActionResult> Choose(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Schedules.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Schedules.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                Context.Update(schedule);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View(schedule);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Schedules.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Context.Schedules.Remove(await Context.Schedules.FindAsync(id));
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
