using System.ComponentModel.DataAnnotations.Schema;

namespace Tranier_System.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public string Address { get; set; }
        public int Degree { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<CrsResult> CrsResult { get; set; }
    }
}
