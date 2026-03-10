using System.ComponentModel.DataAnnotations;

namespace PROJECT.DTOs
{
    public class CreateUserDTO
    {
        [Required]
        public string name { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string password_hash { get; set; }
    }
}