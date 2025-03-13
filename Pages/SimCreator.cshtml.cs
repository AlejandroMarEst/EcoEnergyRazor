using CsvHelper;
using CsvHelper.Configuration;
using EcoEnergyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using static EcoEnergyRazor.Models.EnergySystem;

namespace EcoEnergyRazor.Pages
{
    // PageModel for creating energy simulations
    public class SimCreatorModel : PageModel
    {
        [BindProperty]
        public EnergySystem? EnergySystem { get; set; }
        [BindProperty]
        public SolarSystem? SolarSystem { get; set; }
        [BindProperty]
        public HydroElectricSystem? HydroElectricSystem { get; set; }
        [BindProperty]
        public EolicSystem? EolicSystem { get; set; }
        [BindProperty]
        public EnergyType? Type { get; set; }

        public IActionResult OnPost()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            // Validate inputs based on energy type
            switch (Type)
            {
                case EnergyType.SolarEnergy:
                    if (SolarSystem != null && SolarSystem.SunHours < 1)
                    {
                        ModelState.AddModelError("SolarSystem.SunHours", "The amount of hours of sun has to be greater than 1h");
                        return Page();
                    }
                    break;
                case EnergyType.EolicEnergy:
                    if (EolicSystem != null && EolicSystem.WindVelocity < 5)
                    {
                        ModelState.AddModelError("EolicSystem.WindVelocity", "The speed of the wind has to be greater than 5km/h");
                        return Page();
                    }
                    break;
                case EnergyType.HydroElectricEnergy:
                    if (HydroElectricSystem != null && HydroElectricSystem.WaterLevel < 20)
                    {
                        ModelState.AddModelError("HydroElectricSystem", "The water level has to be greater than 20m");
                        return Page();
                    }
                    break;
            }

            const string FilePath = "wwwroot/Files/simulations_energy.csv";
            using var file = System.IO.File.Open(FilePath, FileMode.Append);
            using var writer = new StreamWriter(file);
            using var csv = new CsvWriter(writer, config);
            csv.NextRecord();

            // Save the appropriate simulation record based on the energy type
            switch (Type)
            {
                case EnergyType.SolarEnergy:
                    SolarSystem simulationSolar = new SolarSystem(SolarSystem!.SunHours, EnergySystem!.Price, EnergySystem.Ratio, EnergySystem.Cost);
                    csv.WriteRecord(simulationSolar);
                    break;
                case EnergyType.EolicEnergy:
                    EolicSystem simulationEolic = new EolicSystem(EolicSystem!.WindVelocity, EnergySystem!.Price, EnergySystem.Ratio, EnergySystem.Cost);
                    csv.WriteRecord(simulationEolic);
                    break;
                case EnergyType.HydroElectricEnergy:
                    HydroElectricSystem simulationWater = new HydroElectricSystem(HydroElectricSystem!.WaterLevel, EnergySystem!.Price, EnergySystem.Ratio, EnergySystem.Cost);
                    csv.WriteRecord(simulationWater);
                    break;
            }
            return RedirectToPage("Simulations");
        }
    }
}
