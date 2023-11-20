using System.ComponentModel.DataAnnotations;

namespace BookingApplication.Entities
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    } // modelul LoginModel este folosit doar ca o clasă de transfer de date între frontend și backend
}
