using Microsoft.AspNetCore.Mvc;
using KPI_Schedule.Models;

namespace KPI_Schedule.Controllers
{
    public class HomeController : Controller
    {
        public DbSchedule Context { get; }
        public HomeController(DbSchedule context)
        {
            Context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
