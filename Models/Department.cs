using System.Collections.Generic;

namespace KPI_Schedule.Models
{
    public class Department
    {
        public int Id { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public List<Group> Groups { get; set; }
    }
}
