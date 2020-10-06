using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using KPI_Schedule.Models;

namespace KPI_Schedules.Controllers
{
    public class ScheduleController : Controller
    {
        public DbSchedule Context { get; }
        public ScheduleController(DbSchedule context) => Context = context;

        public async Task<IActionResult> List()
        {
            return View(await Context.Schedules.Include(n => n.Teacher).Include(n => n.Discipline).Include(n => n.Group).ToListAsync());
        }

        public IActionResult Create()
        {
            List<Teacher> listT = new List<Teacher>();
            List<Discipline> listD = new List<Discipline>();
            List<Group> listG = new List<Group>();

            foreach (Teacher item in Context.Teachers)
                listT.Add(item);
            foreach (Discipline item in Context.Disciplines)
                listD.Add(item);
            foreach (Group item in Context.Groups)
                listG.Add(item);

            ViewBag.TeacherIdName = new SelectList(listT, "Id", "Name", listT[0]);
            ViewBag.TeacherIdSurname = new SelectList(listT, "Id", "Surname", listT[0]);
            ViewBag.DisciplineId = new SelectList(listD, "Id", "Name", listD[0]);
            ViewBag.GroupId = new SelectList(listG, "Id", "Name", listG[0]);

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

            var element = await Context.Schedules.Include(n => n.Teacher).Include(n => n.Discipline).Include(n => n.Group).FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            return View(element);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var element = await Context.Schedules.Include(n => n.Teacher).Include(n => n.Discipline).Include(n => n.Group).FirstOrDefaultAsync(e => e.Id == id);

            if (element == null)
                return NotFound();

            List<Teacher> listT = new List<Teacher>();
            List<Discipline> listD = new List<Discipline>();
            List<Group> listG = new List<Group>();

            foreach (Teacher item in Context.Teachers)
                listT.Add(item);
            foreach (Discipline item in Context.Disciplines)
                listD.Add(item);
            foreach (Group item in Context.Groups)
                listG.Add(item);

            ViewBag.TeacherIdName = new SelectList(listT, "Id", "Name", element.TeacherId);
            ViewBag.TeacherIdSurname = new SelectList(listT, "Id", "Surname", element.TeacherId);
            ViewBag.DisciplineId = new SelectList(listD, "Id", "Name", element.DisciplineId);
            ViewBag.GroupId = new SelectList(listG, "Id", "Name", element.GroupId);

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

            var element = await Context.Schedules.Include(n => n.Teacher).Include(n => n.Discipline).Include(n => n.Group).FirstOrDefaultAsync(e => e.Id == id);

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
