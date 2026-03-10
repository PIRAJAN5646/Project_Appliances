using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJECT.Data
{
    public class Appliances
    {
        [Key]
        public int appliance_id { get; set; }
        [ForeignKey("ApplianceType")]
        public int type_id { get; set; }
        [ForeignKey("Homes")]
        public int home_id { get; set; }
        public string model { get; set; }
        public string name { get; set; }
        public string device_identifier { get; set; }
        public DateTime installed_at { get; set; }
        public string status { get; set; }
    }
}
