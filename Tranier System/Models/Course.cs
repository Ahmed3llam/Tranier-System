using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tranier_System.Models
{
    public class Course
    {
        public int Id { get; set; }
        [UniqueCrs]
        [MinLength(1,ErrorMessage ="Name must be more than 1 letters")]
        [MaxLength(30,ErrorMessage = "Name must be less than 30 letters")]
        public string Name { get; set; }
        [Range(50,100,ErrorMessage ="Grade must be in range 50 to 100")]
        public int Degree { get; set; }
        [Remote("CheckMinDegree","Course",ErrorMessage ="Min Degree Value Must Less Than Degree",AdditionalFields = "Degree")]
        public int MinDegree { get; set; }
        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
        public virtual List<Instructor>? Instructors { get; set; }
        public virtual List<CrsResult>? CrsResult { get; set; }
    }
}
