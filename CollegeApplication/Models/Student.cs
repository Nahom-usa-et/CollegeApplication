using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CollegeApplication.CustomValidations;
//helps to deployee modal validation.....DataAnnotation
namespace CollegeApplication.Models
{
    public class Student
    {  
        [Required]
        [Key]
        public int ? Id { get; set; }

        [Required, StringLength(10)]
        [MaxLength(200)]
        public string ? Name { get; set; }

        [Required, EmailAddress]
        [MaxLength(250)]
        public string ? Email { get; set; }
         
        [Phone]
        [MaxLength(20)]
        public string ? phone  { get; set; }
           
        [Required]
        [PasswordPropertyText]
        [MaxLength(20)]
        public string ? password { get; set; }

        [Required, MaxLength(20)]
        [Compare ("password")]
        public string? ConfirmPassword { get; set; }

        [Required]
        [ValidateAddmisiondate]

        public DateTime? addmisiondate {  get; set; }

    }
}
