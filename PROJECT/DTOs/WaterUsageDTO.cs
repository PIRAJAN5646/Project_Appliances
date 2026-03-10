namespace PROJECT.DTOs
{
    public class WaterUsageDTO
    {
        public int appliance_id { get; set; }

        public DateTime date { get; set; }

        public double liters_consumed { get; set; }

        public int cycle_count { get; set; }

        public double cost_estimate { get; set; }
    }
}