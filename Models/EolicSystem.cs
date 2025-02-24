using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EcoEnergyRazor.Models
{
    public class EolicSystem : EnergySystem, IEnergyCalculation
    {
        public double WindVelocity { get; set; }
        public EolicSystem(double windVelocity)
        {
            if (!CheckParameter(windVelocity))
            {
                const string minWindVelocity = "A minimum of 5 meters per second are required.";
                throw new ArgumentOutOfRangeException(nameof(windVelocity), minWindVelocity);
            }
            Type = "Wind energy";
            WindVelocity = windVelocity;
            Energy = EnergyCalculation();
            Date = DateTime.Now;
            SimulationNumber++;
        }
        public double EnergyCalculation() => Math.Round(Math.Pow(WindVelocity, 3) * 0.2, 2);
        public bool CheckParameter(double energyMethod) => energyMethod >= 5;
        public string ShowSimulation()
        {
            return $"\n\t\t{SimulationNumber}\t\t\t{Type}\t\t\t{Energy}\t\t\t{Date}\t";
        }
    }
}
