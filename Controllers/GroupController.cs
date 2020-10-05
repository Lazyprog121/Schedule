using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KPI_Schedule.Models;

namespace KPI_Schedule.Controllers
{
    public class GroupController : Controller
    {
        public DbSchedule Context { get; }
        public GroupController(DbSchedule context) => Context = context;

        public async Task<IActionResult> List()
        {
            return View(await Context.Groups.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Group group)
        {
            if (ModelState.IsValid)
            {
                Context.Add(group);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View(group);
        }

        public async Task<IActionResult> Choose(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Groups.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Groups.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Group group)
        {
            if (ModelState.IsValid)
            {
                Context.Update(group);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View(group);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Groups.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Context.Groups.Remove(await Context.Groups.FindAsync(id));
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
