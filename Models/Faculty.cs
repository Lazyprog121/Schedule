using System.Collections.Generic;

namespace KPI_Schedule.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public List<Department> Departments { get; set; }
    }
}
