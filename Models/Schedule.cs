namespace KPI_Schedule.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public string Time { get; set; }
        public string Classroom { get; set; }
    }
}
