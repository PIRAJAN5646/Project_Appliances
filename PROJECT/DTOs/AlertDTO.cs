namespace PROJECT.DTOs
{
    public class AlertsDTO
    {
        public int appliance_id { get; set; }

        public string alert_type { get; set; }

        public string message { get; set; }

        public bool is_resolved { get; set; }

        public int severity { get; set; }
    }
}