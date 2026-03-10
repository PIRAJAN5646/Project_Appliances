namespace PROJECT.DTOs
{
    public class CreateApplianceTypeDTO
    {
        public string name { get; set; }

        public string category { get; set; }

        public double avg_energy_rating { get; set; }

        public double avg_water_rating { get; set; }
    }
}