using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJECT.Data
{
    public class Notification
    {
        [ForeignKey("User")]
        public int user_id { get; set; }
        public User User { get; set; }
        [Key]
        public int notification_id { get; set; }
        [ForeignKey("Alert")]
        public int alert_id { get; set; }
        public Alert Alert { get; set; }
        public int channel { get; set; }
        public DateTime sent_at { get; set; }= DateTime.Now;
        public DateTime read_at { get; set; }
    }
}
