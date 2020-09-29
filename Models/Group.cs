using System.Collections.Generic;

namespace KPI_Schedule.Models
{
    public class Group
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Name { get; set; }
        public int Course { get; set; }

        public List<Schedule> Schedules { get; set; }
        public List<Student> Students { get; set; }
    }
}
