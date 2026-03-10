using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJECT.Data
{
    public class Alerts
    {
        [Key]
        public int alert_id { get; set; }
        [ForeignKey("Appliances")]
        public int appliance_id { get; set; }
        [Required]
        public string alert_type { get; set; }
        [Required]
        public string message { get; set; }
        [Required]
        public Boolean is_resolved { get; set; }
        [Required]
        public double severity { get; set; }
        public DateTime created_at { get; set; }= DateTime.Now;
    }
}
