using Domain;

namespace Dal.Mappings
{
    public sealed class TouMap : BaseMap<TouCsv>
    {
        public TouMap()
        {
            Map(m => m.Energy).Name("Energy");
            Map(m => m.MaximumDemand).Name("Maximum Demand");
            Map(m => m.TimeOfMaxDemand).Name("Time of Max Demand");
            Map(m => m.DlsActive).Name("DLS Active");
            Map(m => m.BillingResetCount).Name("Billing Reset Count");
            Map(m => m.BillingResetDateTime).Name("Billing Reset Date/Time");
        }
    }
}
