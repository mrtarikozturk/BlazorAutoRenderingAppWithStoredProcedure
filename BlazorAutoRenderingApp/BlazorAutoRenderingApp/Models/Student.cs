using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorAutoRenderingApp.Models
{
	public class Student
	{
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Range(18, 25)]
        public int Age { get; set; }

        [DisplayName("Date of Birth")]
        public DateTime Birthday { get; set; }
    }
}
