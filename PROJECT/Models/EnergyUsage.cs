using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJECT.Data
{
    public class EnergyUsage
    {
        [Key]
        public int energy_usage_id {  get; set; }
        [ForeignKey("Appliance")]
        public int appliance_id { get; set; }
        [Required]
        public DateTime date { get; set; }
        public double cost_estimated { get; set; }
        public double peak_usage {  get; set; }
        [Required]
        public double kwh_consumed { get; set; }
    }
}
