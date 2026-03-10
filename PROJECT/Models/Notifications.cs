using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJECT.Data
{
    public class Notifications
    {
        [ForeignKey("Users")]
        public int user_id { get; set; }
        [Key]
        public int notification_id { get; set; }
        [ForeignKey("Alerts")]
        public int alert_id { get; set; }
        public int channel { get; set; }
        public DateTime sent_at { get; set; }= DateTime.Now;
        public DateTime read_at { get; set; }
    }
}
