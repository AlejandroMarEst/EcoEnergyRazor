namespace EcoEnergyRazor.Models
{
    public class SolarSystem : EnergySystem, IEnergyCalculation
    {
        public double SunHours { get; set; }
        public SolarSystem(double sunHours)
        {
            if (!CheckParameter(sunHours))
            {
                const string minSunHours = "A minimum of 1 hour is required.";
                throw new ArgumentOutOfRangeException(nameof(sunHours), minSunHours);
            }
            Type = "Sun energy";
            SunHours = sunHours;
            Energy = EnergyCalculation();
            Date = DateTime.Now;
            SimulationNumber++;
        }
        public SolarSystem(double sunHours, DateTime date)
        {
            if (!CheckParameter(sunHours))
            {
                const string minSunHours = "A minimum of 1 hour is required.";
                throw new ArgumentOutOfRangeException(nameof(sunHours), minSunHours);
            }
            Type = "Sun energy";
            SunHours = sunHours;
            Energy = EnergyCalculation();
            Date = date;
            SimulationNumber++;
        }
        public double EnergyCalculation() => Math.Round(SunHours * 1.5, 2);
        public bool CheckParameter(double energyMethod) => energyMethod >= 1;
        public string ShowSimulation()
        {
            return $"\n\t\t{SimulationNumber}\t\t\t{Type}\t\t\t{Energy}\t\t\t{Date}\t";
        }
    }
}
