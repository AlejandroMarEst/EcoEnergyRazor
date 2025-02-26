using EcoEnergyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CsvHelper;
using System.Globalization;

namespace EcoEnergyRazor.Pages
{
    public class SimulationsModel : PageModel
    {
        public List<EnergySystem> Simulations { get; set; } = new List<EnergySystem>();
        public bool Empty = false;
        public void OnGet()
        {
            string filePath = "Files\\Simulations.csv";
            if (System.IO.File.Exists(filePath))
            {using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    if (System.IO.File.Exists(filePath))
                    {
                        var registres = csv.GetRecords<EnergySystem>();
                        foreach (var line in registres)
                        {
                            Simulations.Add(line);
                        }
                    }
            } else
            {
                Empty = true;
            }
        }
    }
}
