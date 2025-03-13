using EcoEnergyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace EcoEnergyRazor.Pages
{
    public class AddWaterConsumptionModel : PageModel
    {
        [BindProperty]
        public WaterConsumptionLog? WaterConsumption { get; set; }

        public IActionResult OnPost()
        {
            const string filePath = "wwwroot/Files/consum_aigua_cat_per_comarques.xml";

            // Checks if file exists already
            XDocument xmlDoc;
            if (System.IO.File.Exists(filePath))
            {
                xmlDoc = XDocument.Load(filePath);
            }
            else
            {
                // If the file doesnt exist it creates it
                xmlDoc = new XDocument(new XElement("WaterConsumptions"));
            }

            // Adds new element 
            XElement newConsumption = new XElement("WaterConsumption",
                new XElement("Year", WaterConsumption!.Year),
                new XElement("Region",
                    new XElement("ID", WaterConsumption.RegionID),
                    new XElement("Name", WaterConsumption.RegionName)
                ),
                new XElement("Population", WaterConsumption.Population),
                new XElement("DomesticNET", WaterConsumption.DomesticNET),
                new XElement("EconomicActivities", WaterConsumption.EconomicActivities),
                new XElement("Total", WaterConsumption.Total),
                new XElement("DomesticConsumption", WaterConsumption.DomesticConsumption)
            );

            if(xmlDoc.Root!=null)
            {
                // Adds new water consumption 
                xmlDoc.Root.Add(newConsumption);

                // Saves XML document
                xmlDoc.Save(filePath);
            }

            return RedirectToPage("WaterConsumption");
        }
    }
}
