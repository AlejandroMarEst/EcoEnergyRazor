using CsvHelper;
using CsvHelper.Configuration;
using EcoEnergyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace EcoEnergyRazor.Pages
{
    public class EnergeticIndicatorsModel : PageModel
    {
        // Flags to indicate file existence and records availability
        public bool FileExists { get; set; }
        public bool FileHasRecords { get; set; }

        // Lists to store energy indicators and calculated averages
        public List<EnergyIndicator> EnergyIndicatorList { get; set; } = new List<EnergyIndicator>();
        public List<AvgEnergeticIndicator> AvgNetProductionPerYear { get; set; } = new List<AvgEnergeticIndicator>();
        public List<EnergyIndicator> ElectricityDemand { get; set; } = new List<EnergyIndicator>();

        public void OnGet()
        {
            // Define file path
            const string fileRoute = "wwwroot/Files/indicadors_energetics_cat.csv";
            FileExists = System.IO.File.Exists(fileRoute);

            if (FileExists)
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                };

                using (var reader = new StreamReader(fileRoute))
                using (var csv = new CsvReader(reader, config))
                {
                    // Load CSV records
                    var records = csv.GetRecords<EnergyIndicator>();
                    foreach (var record in records)
                    {
                        EnergyIndicatorList.Add(record);
                    }

                    FileHasRecords = EnergyIndicatorList.Count > 0;

                    // Calculate average net production per year
                    AvgNetProductionPerYear = EnergyIndicatorList.GroupBy(v => v.Date.Year).Select(x => new AvgEnergeticIndicator
                    {
                        Year = x.Key,
                        AvgNetProd = x.Average(y => y.CDEEBC_NetProduction)
                    }).OrderBy(avgProd => avgProd.AvgNetProd).ToList();

                    // Filter electricity demand records
                    ElectricityDemand = EnergyIndicatorList.Where(x => x.CDEEBC_ElectricDemand > 4000 && x.CDEEBC_AvailableProduction < 300).ToList();
                }
            }
        }
    }
}
