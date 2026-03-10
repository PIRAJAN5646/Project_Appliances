using System.ComponentModel.DataAnnotations;

namespace PROJECT.Data
{
    public class ApplianceType
    {
        [Key]
        public int type_id {  get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public double avg_energy_rating { get; set; }
        [Required]
        public double avg_water_rating { get;set; }
    }
}
