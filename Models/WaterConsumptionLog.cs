using System.ComponentModel.DataAnnotations;

namespace EcoEnergyRazor.Models
{
    public class WaterConsumptionLog
    {
        [Required(ErrorMessage = "This field is necessary")]
        public int Year { get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public int RegionID { get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public string? RegionName { get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public int Population { get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public int DomesticNET { get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public int EconomicActivities { get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public int Total { get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public double DomesticConsumption { get; set; }
    }
}
