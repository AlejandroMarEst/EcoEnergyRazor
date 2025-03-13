using EcoEnergyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;

namespace EcoEnergyRazor.Pages
{
    // PageModel for displaying saved energy simulations
    public class SimulationsModel : PageModel
    {
        public List<EnergySystem> Simulations { get; set; } = new List<EnergySystem>();
        public bool FileExists { get; set; }
        public bool FileHasRecords { get; set; }

        public void OnGet()
        {
            const string filePath = "wwwroot/Files/simulations_energy.csv";
            FileExists = System.IO.File.Exists(filePath);

            // If the file exists, read the simulations from the CSV file
            if (FileExists)
            {
                using var reader = new StreamReader(filePath);
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var registres = csv.GetRecords<EnergySystem>();
                    foreach (var line in registres)
                    {
                        Simulations.Add(line);
                    }
                    FileHasRecords = Simulations.Count > 0;
                }
            }
        }
    }
}
