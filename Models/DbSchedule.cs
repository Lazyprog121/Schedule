using Microsoft.EntityFrameworkCore;

namespace KPI_Schedule.Models
{
    public class DbSchedule : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<SettingUniversity> SettingUniversity { get; set; }
        public DbSchedule(DbContextOptions<DbSchedule> options) : base(options)
        {
        }
    }
}
