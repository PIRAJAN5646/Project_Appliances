namespace PROJECT.DTOs
{
    public class SustainabilityScoreDTO
    {
        public int home_id { get; set; }

        public DateTime period_start { get; set; }

        public DateTime period_end { get; set; }

        public double energy_score { get; set; }

        public double water_score { get; set; }

        public double overall_score { get; set; }
    }
}