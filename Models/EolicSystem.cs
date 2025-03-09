using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcoEnergyRazor.Models
{
    public class EolicSystem : EnergySystem, IEnergyCalculation
    {
        public double WindVelocity { get; set; }
        public EolicSystem(double windVelocity, double price, double ratio, double cost)
        {
            if (!CheckParameter(windVelocity))
            {
                const string minWindVelocity = "A minimum of 5 meters per second are required.";
                throw new ArgumentOutOfRangeException(nameof(windVelocity), minWindVelocity);
            }
            Type = EnergyType.EolicEnergy;
            WindVelocity = windVelocity;
            Energy = EnergyCalculation();
            Date = DateTime.Now;
            SimulationNumber++; Price = price;
            Ratio = ratio;
            Cost = cost;
            TotalCost = CalculateTotalCost();
            TotalPrice = CalculateTotalPrice();
        }
        public EolicSystem(double windVelocity, DateTime date)
        {
            if (!CheckParameter(windVelocity))
            {
                const string minWindVelocity = "A minimum of 5 meters per second are required.";
                throw new ArgumentOutOfRangeException(nameof(windVelocity), minWindVelocity);
            }
            Type = EnergyType.EolicEnergy;
            WindVelocity = windVelocity;
            Energy = EnergyCalculation();
            Date = date;
            SimulationNumber++;
            Price = 0;
            Ratio = 0;
            Cost = 0;
            TotalCost = CalculateTotalCost();
            TotalPrice = CalculateTotalPrice();
        }
        public EolicSystem()
        {
            Type = EnergyType.EolicEnergy;
            WindVelocity = 0;
            Energy = 0;
            Date = DateTime.Now;
            SimulationNumber++;
            Price = 0;
            Ratio = 0;
            Cost = 0;
            TotalCost = CalculateTotalCost();
            TotalPrice = CalculateTotalPrice();
        }
        public double EnergyCalculation() => Math.Round(Math.Pow(WindVelocity, 3) * 0.2, 2);
        public bool CheckParameter(double energyMethod) => energyMethod >= 5;
        public string ShowSimulation()
        {
            return $"\n\t\t{SimulationNumber}\t\t\t{Type}\t\t\t{Energy}\t\t\t{Date}\t";
        }
    }
}
