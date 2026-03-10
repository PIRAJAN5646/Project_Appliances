namespace PROJECT.DTOs
{
    public class EnergyUsageDTO
    {
        public int appliance_id { get; set; }

        public DateTime date { get; set; }

        public double kwh_consumed { get; set; }

        public double peak_usage { get; set; }

        public double cost_estimate { get; set; }
    }
}