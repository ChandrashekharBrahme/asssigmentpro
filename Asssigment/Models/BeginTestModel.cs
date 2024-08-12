using System.ComponentModel.DataAnnotations;

namespace Asssigment.Models
{
    public class BeginTestModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public required string Email { get; set; }
    }
}
