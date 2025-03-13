using System.ComponentModel.DataAnnotations;

namespace EcoEnergyRazor.Models
{
    public class EnergyIndicator
    {
        [Required(ErrorMessage = "This camp is required")]
        public DateTime Date { get; set; }
        public double PBEE_Hydroelectric { get; set; }
        public double PBEE_Coal { get; set; }
        public double PBEE_NaturalGas { get; set; }
        public double PBEE_FuelOil { get; set; }
        public double PBEE_CombinedCycle { get; set; }
        public double PBEE_Nuclear { get; set; }
        public double CDEEBC_GrossProduction { get; set; }
        public double CDEEBC_AuxConsumption { get; set; }
        [Required(ErrorMessage = "This camp is required")]
        public double CDEEBC_NetProduction { get; set; }
        public double CDEEBC_PumpConsumption { get; set; }
        [Required(ErrorMessage = "This camp is required")]
        public double CDEEBC_AvailableProduction { get; set; }
        public double CDEEBC_TotalNetworkSalesCentral { get; set; }
        public double CDEEBC_ElectricExchangeBalance { get; set; }
        [Required(ErrorMessage = "This camp is required")]
        public double CDEEBC_ElectricDemand { get; set; }
        public double CDEEBC_TotalRegulatedMarket { get; set; }
        public double CDEEBC_TotalFreeMarket { get; set; }
        public double? FEE_Industry { get; set; }
        public double? FEE_Tertiary { get; set; }
        public double? FEE_Domestic { get; set; }
        public double? FEE_Primary { get; set; }
        public double? FEE_Energetic { get; set; }
        public double? FEEI_PublicWorksConsumption { get; set; }
        public double? FEEI_IronSteelFoundry { get; set; }
        public double? FEEI_Metallurgy { get; set; }
        public double? FEEI_GlassIndustry { get; set; }
        public double? FEEI_CementLimeGypsum { get; set; }
        public double? FEEI_OtherConstructionMaterials { get; set; }
        public double? FEEI_ChemicalPetrochemical { get; set; }
        public double? FEEI_TransportMediumConstruction { get; set; }
        public double? FEEI_OtherMetalTransformation { get; set; }
        public double? FEEI_FoodBeverageTobacco { get; set; }
        public double? FEEI_TextileClothingLeatherFootwear { get; set; }
        public double? FEEI_PulpPaperCardboard { get; set; }
        public double? FEEI_OtherIndustries { get; set; }
        public double DGGN_FrontierPointEnagas { get; set; }
        public double DGGN_LNGDistributionSupply { get; set; }
        public double DGGN_ThermalPowerPlantGNCConsumption { get; set; }
        [Required(ErrorMessage = "This camp is required")]
        public double CCAC_AutoGasoline { get; set; }
        public double CCAC_AutoDieselA { get; set; }
    }
}
