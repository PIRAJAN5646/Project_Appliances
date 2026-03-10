using System.ComponentModel.DataAnnotations;

namespace PROJECT.Data
{
    public class User
    {
        [Key]
        public int user_id{ get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password_hash { get; set; }
        public DateTime created_at{ get; set; }= DateTime.Now;
        public DateTime updated_at { get; set; }
    }
}