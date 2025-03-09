using CsvHelper;
using CsvHelper.Configuration;
using EcoEnergyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using static EcoEnergyRazor.Models.EnergySystem;

namespace EcoEnergyRazor.Pages
{
    public class SimCreatorModel : PageModel
    {
        [BindProperty]
        public SolarSystem EnergySystem { get; set; }
        [BindProperty]
        public SolarSystem SolarSystem { get; set; }
        [BindProperty]
        public HydroElectricSystem HydroElectricSystem { get; set; }
        [BindProperty]
        public EolicSystem EolicSystem { get; set; }
        [BindProperty]
        public EnergyType? Type { get; set; }
        public void OnGet() { }
        public IActionResult OnPost()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            switch (Type)
            {
                case EnergyType.SolarEnergy:
                    if (SolarSystem.SunHours < 1)
                    {
                        ModelState.AddModelError("SolarSystem.SunHours", "The amount of hours of sun has to be greater than 1h");
                        return Page();
                    }
                    break;
                case EnergyType.EolicEnergy:
                    if (EolicSystem.WindVelocity < 5)
                    {
                        ModelState.AddModelError("EolicSystem.WindVelocity", "The speed of the wind has to be greater than 5km/h");
                        return Page();
                    }
                    break;
                case EnergyType.HydroElectricEnergy:
                    if (HydroElectricSystem.WaterLevel < 20)
                    {
                        ModelState.AddModelError("HydroElectricSystem", "The speed of the wind has to be greater than 5km/h");
                        return Page();
                    }
                    break;
            }
            
            using var file = System.IO.File.Open("wwwroot/Files/simulations_energy.csv", FileMode.Append);
            using var writer = new StreamWriter(file);
            using var csv = new CsvWriter(writer, config);
            csv.NextRecord();
            switch (Type)
            {
                case EnergyType.SolarEnergy:
                    SolarSystem simulationSolar = new SolarSystem(SolarSystem.SunHours, EnergySystem.Price, EnergySystem.Ratio, EnergySystem.Cost);
                    csv.WriteRecord(simulationSolar);
                    break;
                case EnergyType.EolicEnergy:
                    EolicSystem simulationEolic = new EolicSystem(EolicSystem.WindVelocity, EnergySystem.Price, EnergySystem.Ratio, EnergySystem.Cost);
                    csv.WriteRecord(simulationEolic);
                    break;
                case EnergyType.HydroElectricEnergy:
                    HydroElectricSystem simulationWater = new HydroElectricSystem(HydroElectricSystem.WaterLevel, EnergySystem.Price, EnergySystem.Ratio, EnergySystem.Cost);
                    csv.WriteRecord(simulationWater);
                    break;
            }
            return RedirectToPage("Simulations");
        }
    }
}
