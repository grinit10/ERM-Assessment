using System;

namespace Domain
{
    public class TouCsv : BaseModel
    {
        public float Energy { get; set; }
        public float MaximumDemand { get; set; }
        public DateTime TimeOfMaxDemand { get; set; }
        public string Period { get; set; }
        public bool DlsActive { get; set; }
        public int BillingResetCount { get; set; }
        public DateTime BillingResetDateTime { get; set; }
        public string Rate { get; set; }
    }
}
