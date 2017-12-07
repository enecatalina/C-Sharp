using System.ComponentModel.DataAnnotations;

namespace Wall.Models 
{
    public class Users: BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginRegisterViewModel : BaseEntity    //register wrapper
    {
        public LoginViewModel loginVM { get; set; }
        public RegisterViewModel registerVM { get; set; }
    }
    public class RegisterViewModel : BaseEntity   
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
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