using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJECT.Data
{
    public class SustainabilityScore
    {
        [ForeignKey("Home")]
        public int home_id { get; set; }
        public Home Home { get; set; }
        [Key]
        public int sustainablity_score_id { get; set; }
        public DateTime period_start { get; set; }
        public double energy_score { get; set; }
        public double water_score { get; set; }
        public DateTime period_end { get; set; }
        public double overall_score { get; set; }

    }









}