using System.Collections.Generic;

namespace KPI_Schedule.Models
{
    public class Discipline
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Schedule> Schedules { get; set; }
    }
}
