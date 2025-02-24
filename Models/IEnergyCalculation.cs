namespace EcoEnergyRazor.Models
{
    public interface IEnergyCalculation
    {
        /// <summary>
        /// Calculates the amount of energy produced
        /// </summary>
        /// <returns> The amoung of energy produced </returns>
        double EnergyCalculation();
        /// <summary>
        /// Checks if a number is inside the established limits
        /// </summary>
        /// <param name="energyMethod"> The number to get checked </param>
        /// <returns> Returns if the parameter is inside the limits or not</returns>
        bool CheckParameter(double energyMethod);
        /// <summary>
        /// Gets info in the simulation, like the type, energy, etc
        /// </summary>
        /// <returns> The info of the simulation in string form</returns>
        string ShowSimulation();
    }
}
