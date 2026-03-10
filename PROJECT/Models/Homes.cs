using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJECT.Data
{
    public class Homes
    {
        [ForeignKey("Users")]
        public int user_id { get; set; }
        [Key]
        public int home_id { get; set; }
        [Required]
        public string name { get; set; }
        public DateTime created_at { get; set; }=DateTime.Now;
        [Required]
        public string address { get; set; }
    }
}
