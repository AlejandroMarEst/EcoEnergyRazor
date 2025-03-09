using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcoEnergyRazor.Models
{
    public class HydroElectricSystem : EnergySystem, IEnergyCalculation
    {
        public double WaterLevel { get; set; }
        public HydroElectricSystem(double waterLevel, double price, double ratio, double cost)
        {
            if (!CheckParameter(waterLevel))
            {
                const string minWaterLevel = "A minimum of 20 cubic meters are required.";
                throw new ArgumentOutOfRangeException(nameof(waterLevel), minWaterLevel);
            }
            Type = EnergyType.HydroElectricEnergy;
            WaterLevel = waterLevel;
            Energy = EnergyCalculation();
            Date = DateTime.Now;
            SimulationNumber++;
            Price = price;
            Ratio = ratio;
            Cost = cost;
            TotalCost = CalculateTotalCost();
            TotalPrice = CalculateTotalPrice();
        }
        public HydroElectricSystem(double waterLevel, DateTime date)
        {
            if (!CheckParameter(waterLevel))
            {
                const string minWaterLevel = "A minimum of 20 cubic meters are required.";
                throw new ArgumentOutOfRangeException(nameof(waterLevel), minWaterLevel);
            }
            Type = EnergyType.HydroElectricEnergy;
            WaterLevel = waterLevel;
            Energy = EnergyCalculation();
            Date = date;
            SimulationNumber++;
            Price = 0;
            Ratio = 0;
            Cost = 0;
            TotalCost = CalculateTotalCost();
            TotalPrice = CalculateTotalPrice();
        }
        public HydroElectricSystem()
        {
            Type = EnergyType.HydroElectricEnergy;
            WaterLevel = 0;
            Energy = 0;
            Date = DateTime.Now;
            Price = 0;
            Ratio = 0;
            Cost = 0;
            TotalCost = CalculateTotalCost();
            TotalPrice = CalculateTotalPrice();
        }
        public double EnergyCalculation() => Math.Round(WaterLevel * 9.8 * 0.8, 2);
        public bool CheckParameter(double energyMethod) => energyMethod >= 20;
        public string ShowSimulation()
        {
            return $"\n\t\t{SimulationNumber}\t\t\t{Type}\t\t{Energy}\t\t\t{Date}\t";
        }
    }
}
