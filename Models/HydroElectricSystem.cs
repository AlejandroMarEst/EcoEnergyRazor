using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcoEnergyRazor.Models
{
    public class HydroElectricSystem : EnergySystem, IEnergyCalculation
    {
        public double WaterLevel { get; set; }
        public HydroElectricSystem(double waterLevel)
        {
            if (!CheckParameter(waterLevel))
            {
                const string minWaterLevel = "A minimum of 20 cubic meters are required.";
                throw new ArgumentOutOfRangeException(nameof(waterLevel), minWaterLevel);
            }
            Type = "Hydroelectric energy";
            WaterLevel = waterLevel;
            Energy = EnergyCalculation();
            Date = DateTime.Now;
            SimulationNumber++;
        }
        public double EnergyCalculation() => Math.Round(WaterLevel * 9.8 * 0.8, 2);
        public bool CheckParameter(double energyMethod) => energyMethod >= 20;
        public string ShowSimulation()
        {
            return $"\n\t\t{SimulationNumber}\t\t\t{Type}\t\t{Energy}\t\t\t{Date}\t";
        }
    }
}
