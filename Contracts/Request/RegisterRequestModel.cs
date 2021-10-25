using System.ComponentModel.DataAnnotations;

namespace Contracts.Request
{
    public class RegisterRequestModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}