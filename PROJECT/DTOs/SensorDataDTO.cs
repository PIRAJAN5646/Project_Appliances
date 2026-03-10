namespace PROJECT.DTOs
{
    public class SensorDataDTO
    {
        public int appliance_id { get; set; }

        public string reading_type { get; set; }

        public double value { get; set; }

        public int unit { get; set; }
    }
}