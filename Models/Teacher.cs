using System.Collections.Generic;

namespace KPI_Schedule.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<Schedule> Schedules { get; set; }
    }
}
