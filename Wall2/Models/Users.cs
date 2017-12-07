using System.ComponentModel.DataAnnotations;

namespace Wall2.Models
{
    public class Users : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [Compare("Password")]   //validator that two fields contain the same value. Only need sto be applied to one of the fields 
        public string ConfirmPassword { get; set; }
    }
    public class LoginViewModel : BaseEntity
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string loginEmail { get; set; }
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string loginPassword { get; set; }
    }
}