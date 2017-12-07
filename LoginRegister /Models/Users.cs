using System.ComponentModel.DataAnnotations;

namespace LoginRegister.Models
{
    public class Users: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    //User is logging in 
    public class LoginViewModel: BaseEntity
    {
        [Required]
        public string loginEmail { get; set; }

        [Required]
        public string loginPassword { get; set; }
    }
    //Where the user is registering 
    public class RegisterViewModel : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string RegisterPassword { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }

    //WRAPPER
    //what is connecting the classes together 
    public class LoginRegViewModel : BaseEntity
    {
        public LoginViewModel loginVM { get; set; } 
        public RegisterViewModel registerVM { get; set; }
    }
}