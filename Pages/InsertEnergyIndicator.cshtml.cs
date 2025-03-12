using EcoEnergyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace EcoEnergyRazor.Pages
{
    public class InsertEnergyIndicatorModel : PageModel
    {
        [BindProperty]
        public EnergyIndicator EnergyIndicator { get; set; }
        public IActionResult OnPost()
        {
            string jsonPath = "wwwroot/Files/energy_indicators.json";
            double defaultValue = 0;
            EnergyIndicator indicator = new EnergyIndicator
            {
                Date = EnergyIndicator.Date,
                PBEE_Hydroelectric = defaultValue,
                PBEE_Coal = defaultValue,
                PBEE_NaturalGas = defaultValue,
                PBEE_FuelOil = defaultValue,
                PBEE_CombinedCycle = defaultValue,
                PBEE_Nuclear = defaultValue,
                CDEEBC_GrossProduction = defaultValue,
                CDEEBC_AuxConsumption = defaultValue,
                CDEEBC_NetProduction = EnergyIndicator.CDEEBC_NetProduction,
                CDEEBC_PumpConsumption = defaultValue,
                CDEEBC_AvailableProduction = EnergyIndicator.CDEEBC_AvailableProduction,
                CDEEBC_TotalNetworkSalesCentral = defaultValue,
                CDEEBC_ElectricExchangeBalance = defaultValue,
                CDEEBC_ElectricDemand = EnergyIndicator.CDEEBC_ElectricDemand,
                CDEEBC_TotalRegulatedMarket = defaultValue.ToString(),
                CDEEBC_TotalFreeMarket = defaultValue,
                FEE_Industry = defaultValue,
                FEE_Tertiary = defaultValue,
                FEE_Domestic = defaultValue,
                FEE_Primary = defaultValue,
                FEE_Energetic = defaultValue,
                FEEI_PublicWorksConsumption = defaultValue,
                FEEI_IronSteelFoundry = defaultValue,
                FEEI_Metallurgy = defaultValue,
                FEEI_GlassIndustry = defaultValue,
                FEEI_CementLimeGypsum = defaultValue,
                FEEI_OtherConstructionMaterials = defaultValue,
                FEEI_ChemicalPetrochemical = defaultValue,
                FEEI_TransportMediumConstruction = defaultValue,
                FEEI_OtherMetalTransformation = defaultValue,
                FEEI_FoodBeverageTobacco = defaultValue,
                FEEI_TextileClothingLeatherFootwear = defaultValue,
                FEEI_PulpPaperCardboard = defaultValue,
                FEEI_OtherIndustries = defaultValue,
                DGGN_FrontierPointEnagas = defaultValue,
                DGGN_LNGDistributionSupply = defaultValue,
                DGGN_ThermalPowerPlantGNCConsumption = defaultValue,
                CCAC_AutoGasoline = EnergyIndicator.CCAC_AutoGasoline,
                CCAC_AutoDieselA = defaultValue
            };
            List<EnergyIndicator> existingIndicators;
            if (!System.IO.File.Exists(jsonPath))
            {
                System.IO.File.WriteAllText(jsonPath, "");
            }
            string jsonFromFile = System.IO.File.ReadAllText(jsonPath);
            if (!string.IsNullOrEmpty(jsonFromFile))
            {
                existingIndicators = JsonSerializer.Deserialize<List<EnergyIndicator>>(jsonFromFile);
            }
            else
            {
                existingIndicators = new List<EnergyIndicator>();
            }
            existingIndicators.Add(indicator);
            string jsonString = JsonSerializer.Serialize(existingIndicators);
            System.IO.File.WriteAllText(jsonPath, jsonString);
            return RedirectToPage("EnergeticIndicators");
        }
    }
}
