using CsvHelper;
using CsvHelper.Configuration;
using EcoEnergyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace EcoEnergyRazor.Pages
{
    // PageModel for displaying water consumption data
    public class WaterConsumptionModel : PageModel
    {
        public List<WaterConsumptionLog> WaterConsumptionList { get; set; } = new List<WaterConsumptionLog>();
        public List<WaterConsumptionLog> BiggestConsumptions { get; set; } = new List<WaterConsumptionLog>();
        public List<AvgConsumptions> AverageConsumptions { get; set; } = new List<AvgConsumptions>();
        public List<string?> RisingConsumptions { get; set; } = new List<string?>();
        public bool Exists { get; set; } = true;
        public bool HasContent { get; set; } = true;

        // Handles GET request to load water consumption data
        public void OnGet()
        {
            const string filePath = "wwwroot/Files/consum_aigua_cat_per_comarques.csv";

            // Check if the file exists
            if (System.IO.File.Exists(filePath))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                };
                using var reader = new StreamReader(filePath);
                using (var csv = new CsvReader(reader, config))
                {
                    // Read water consumption records from CSV file
                    var records = csv.GetRecords<WaterConsumptionLog>();
                    foreach (var line in records)
                    {
                        WaterConsumptionList.Add(line);
                    }

                    // Check if the file has any content
                    if (WaterConsumptionList.Count == 0)
                    {
                        HasContent = false;
                    }
                    else
                    {
                        // Find the biggest water consumptions for the most recent year
                        BiggestConsumptions = WaterConsumptionList
                            .Where(x => x.Year == WaterConsumptionList.Max(x => x.Year))
                            .OrderByDescending(x => x.Total)
                            .ToList();

                        // Calculate average water consumption per region
                        AverageConsumptions = WaterConsumptionList
                            .GroupBy(y => y.RegionName)
                            .Select(y => new AvgConsumptions { Region = y.Key, AverageConsumption = y.Average(y => y.Total) })
                            .OrderByDescending(y => y.AverageConsumption)
                            .ToList();

                        // Identify regions with increasing water consumption over the last 5 years
                        int maxYear = WaterConsumptionList.Max(x => x.Year);
                        int minYear = maxYear - 5;
                        RisingConsumptions = WaterConsumptionList
                            .Where(z => z.Year >= minYear)
                            .GroupBy(z => z.RegionName)
                            .Where(g =>
                            {
                                var minYearData = g.FirstOrDefault(r => r.Year == minYear);
                                var maxYearData = g.FirstOrDefault(r => r.Year == maxYear);
                                return minYearData != null && maxYearData != null && maxYearData.Total > minYearData.Total;
                            })
                            .Select(g => g.Key)
                            .ToList();
                    }
                }
            }
            else
            {
                Exists = false;
            }
        }
    }
}
