namespace PROJECT.DTOs
{
    public class HomeDTO
    {
        public int home_id { get; set; }

        public int user_id { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public DateTime created_at { get; set; }
    }
}