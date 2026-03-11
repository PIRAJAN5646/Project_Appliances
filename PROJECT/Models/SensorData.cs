using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJECT.Data
{
    public class SensorData
    {
        [Key]
        public int Sensor_id { get; set; }
        [ForeignKey("Appliance")]
        public int appliance_id { get; set; }
        public DateTime timestramp { get; set; }= DateTime.Now;
        public string reading_type { get; set; }
        public String unit {  get; set; }
        public double value { get; set; }
    }
}
