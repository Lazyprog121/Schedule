using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KPI_Schedule.Models;

namespace KPI_Schedule.Controllers
{
    public class SettingUniversityController : Controller
    {
        public DbSchedule Context { get; }
        public SettingUniversityController(DbSchedule context) => Context = context;

        public async Task<IActionResult> List()
        {
            return View(await Context.SettingUniversity.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SettingUniversity settingUniversity)
        {
            if (ModelState.IsValid)
            {
                Context.Add(settingUniversity);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View(settingUniversity);
        }

        public async Task<IActionResult> Choose(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.SettingUniversity.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.SettingUniversity.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SettingUniversity settingUniversity)
        {
            if (ModelState.IsValid)
            {
                Context.Update(settingUniversity);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }

            return View(settingUniversity);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.SettingUniversity.FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Context.SettingUniversity.Remove(await Context.SettingUniversity.FindAsync(id));
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
    }
}
