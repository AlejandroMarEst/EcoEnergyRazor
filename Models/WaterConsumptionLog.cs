namespace EcoEnergyRazor.Models
{
    public class WaterConsumptionLog
    {
        public int Year { get; set; }
        public int RegionID { get; set; }
        public string RegionName { get; set; }
        public int Population { get; set; }
        public int DomesticNET { get; set; }
        public int EconomicActivities { get; set; }
        public int Total { get; set; }
        public double DomesticConsumption { get; set; }
    }
}
