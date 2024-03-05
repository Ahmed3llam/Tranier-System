using System.ComponentModel.DataAnnotations.Schema;

namespace Tranier_System.Models
{
    public class InstDeptVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public int CourseId { get; set; }
        public List<Department> Depts { get; set; }
        public List<Course> Courses { get; set; }
    }
}
