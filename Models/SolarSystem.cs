namespace EcoEnergyRazor.Models
{
    public class SolarSystem : EnergySystem, IEnergyCalculation
    {
        public double SunHours { get; set; }
        public SolarSystem(double sunHours, double price, double ratio, double cost)
        {
            if (!CheckParameter(sunHours))
            {
                const string minSunHours = "A minimum of 1 hour is required.";
                throw new ArgumentOutOfRangeException(nameof(sunHours), minSunHours);
            }
            Type = EnergyType.SolarEnergy;
            SunHours = sunHours;
            Energy = EnergyCalculation();
            Date = DateTime.Now;
            SimulationNumber++;
            Price = price;
            Ratio = ratio;
            Cost = cost;
            TotalCost = CalculateTotalCost();
            TotalPrice = CalculateTotalPrice();
        }
        public SolarSystem(double sunHours, DateTime date)
        {
            if (!CheckParameter(sunHours))
            {
                const string minSunHours = "A minimum of 1 hour is required.";
                throw new ArgumentOutOfRangeException(nameof(sunHours), minSunHours);
            }
            Type = EnergyType.SolarEnergy;
            SunHours = sunHours;
            Energy = EnergyCalculation();
            Date = date;
            SimulationNumber++;
            Price = 0;
            Ratio = 0;
            Cost = 0;
            TotalCost = CalculateTotalCost();
            TotalPrice = CalculateTotalPrice();
        }
        public SolarSystem()
        {
            Type = EnergyType.SolarEnergy;
            SunHours = 0;
            Energy = 0;
            Date = DateTime.Now;
            SimulationNumber++;
            Price = 0;
            Ratio = 0;
            Cost = 0;
            TotalCost = CalculateTotalCost();
            TotalPrice = CalculateTotalPrice();
        }
        public double EnergyCalculation() => Math.Round(SunHours * 1.5, 2);
        public bool CheckParameter(double energyMethod) => energyMethod >= 1;
        public string ShowSimulation()
        {
            return $"\n\t\t{SimulationNumber}\t\t\t{Type}\t\t\t{Energy}\t\t\t{Date}\t";
        }
    }
}
