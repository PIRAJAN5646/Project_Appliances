namespace PROJECT.DTOs
{
    public class CreateApplianceDTO
    {
        public int home_id { get; set; }

        public int type_id { get; set; }

        public string name { get; set; }

        public string model { get; set; }

        public string device_identifier { get; set; }
    }
}