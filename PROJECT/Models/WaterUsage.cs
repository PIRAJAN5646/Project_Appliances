using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJECT.Data
{
    public class WaterUsage
    {
        [Key]
        public int water_usage_id { get; set; }
        [ForeignKey("Appliances")]
        public int appliance_id { get; set; }
        [Required]
        public DateTime date { get; set; }
        public int cycle_count { get; set; }
        public double cost_estimated { get; set; }
        public double liters_consumed { get; set; }
    }
}
