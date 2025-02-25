using EcoEnergyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CsvHelper;

namespace EcoEnergyRazor.Pages
{
    public class SimulationsModel : PageModel
    {
        public List<EnergySystem> Simulations { get; set; } = new List<EnergySystem>();
        public void OnGet()
        {
            string filePath = "\\Files\\TextFile.txt";
            if (System.IO.File.Exists(filePath))
            {
                var lines = System.IO.File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    switch (parts[0])
                    {
                        case "Hydroelectric energy":
                            var hydroSimulation = new HydroElectricSystem(double.Parse(parts[1]), DateTime.Parse(parts[3]));
                            Simulations.Add(hydroSimulation);
                            break;
                        case "Sun energy":
                            var solarSimulation = new SolarSystem(double.Parse(parts[1]), DateTime.Parse(parts[3]));
                            Simulations.Add(solarSimulation);
                            break;
                        case "Wind energy":
                            var windSimulation = new EolicSystem(double.Parse(parts[1]), DateTime.Parse(parts[3]));
                            Simulations.Add(windSimulation);
                            break;
                    }
                }
            }

        }
    }
}
