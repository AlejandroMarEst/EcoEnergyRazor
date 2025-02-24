namespace EcoEnergyRazor.Models
{
    public class EnergySystem
    {
        protected string Type { get; set; }
        protected double Energy { get; set; }
        protected DateTime Date { get; set; }
        public static int SimulationNumber { get; set; }
    }
}
