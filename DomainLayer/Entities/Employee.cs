using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name cannot be empty")]
        public string? Name { get; set; }

        public string? Address { get; set; }
    }
}
