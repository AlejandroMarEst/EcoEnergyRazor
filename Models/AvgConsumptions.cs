using System.ComponentModel.DataAnnotations;

namespace EcoEnergyRazor.Models
{
    public class AvgConsumptions
    {
        [Required(ErrorMessage = "This field is necessary")]
        public string? Region { get; set; }
        [Required(ErrorMessage = "This field is necessary")]
        public double AverageConsumption { get; set; }
    }
}
