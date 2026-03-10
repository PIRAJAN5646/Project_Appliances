namespace PROJECT.DTOs
{
    public class ApplianceDTO
    {
        public int appliance_id { get; set; }

        public int home_id { get; set; }

        public int type_id { get; set; }

        public string name { get; set; }

        public string model { get; set; }

        public string status { get; set; }

        public DateTime installed_at { get; set; }
    }
}