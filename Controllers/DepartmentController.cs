using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KPI_Schedule.Models;

namespace KPI_Schedule.Controllers
{
    public class DepartmentController : Controller
    {
        public DbSchedule Context { get; }
        public DepartmentController(DbSchedule context) => Context = context;

        public async Task<IActionResult> List()
        {
            return View(await Context.Departments.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                Context.Add(department);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View(department);
        }

        public async Task<IActionResult> Choose(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Departments.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Departments.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                Context.Update(department);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View(department);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Departments.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Context.Departments.Remove(await Context.Departments.FindAsync(id));
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
