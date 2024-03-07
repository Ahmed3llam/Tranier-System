using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tranier_System.Models
{
    public class InstDeptVM
    {
        public int Id { get; set; }
        [MinLength(1, ErrorMessage = "Name must be more than 1 letters")]
        [MaxLength(30, ErrorMessage = "Name must be less than 30 letters")]
        public string Name { get; set; }
        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image Must .png or .jpg")]
        public string? Image { get; set; }
        [Range(5000,20000,ErrorMessage ="Salary must between 5k to 20k")]
        public double Salary { get; set; }
        public string Address { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public List<Department> Depts { get; set; }
        public List<Course> Courses { get; set; }
    }
}
