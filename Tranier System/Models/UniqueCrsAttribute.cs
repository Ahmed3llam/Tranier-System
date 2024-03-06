using System.ComponentModel.DataAnnotations;

namespace Tranier_System.Models
{
    public class UniqueCrsAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Course FormCrs = validationContext.ObjectInstance as Course;
            string CrsName = value?.ToString();
            TContext context = new TContext();
            Course course = context.course.FirstOrDefault(c=>c.Name== CrsName && c.DepartmentId==FormCrs.DepartmentId);
            if (course == null)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("This Course Added Before");
        }
    }
}
