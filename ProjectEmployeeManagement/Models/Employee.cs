using System.ComponentModel.DataAnnotations;

namespace ProjectEmployeeManagement.Models
    {
    public class Employee
        {
        public  int Id { get; set; } 
        [Required]
        //[MinLength(3, ErrorMessage = "the name must be at least 3 and maximum 20")]
        //[MaxLength(20, ErrorMessage = "the name must be at least 3 and maximum 20")]
        [RegularExpression(@"[A-Za-z]{3,20}", ErrorMessage = "the name must be at least 3 and maximum 20")]
        public string Name { get; set; }
        [RegularExpression(@"^[\w\.-]+@gmail\.com$", ErrorMessage = "Sorry,the Gmail is InValid")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(77|79|78)\d{7}",ErrorMessage ="Phone Number Is Invalid")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "please select Department")]
        public Department? department { get; set; }
        public string PhotoPath { get; set; } = string.Empty;
        }
    }
