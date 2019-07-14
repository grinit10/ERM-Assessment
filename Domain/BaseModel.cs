using System;

namespace Domain
{
    public class BaseModel
    {
        public int MeterPointCode { get; set; }
        public int SerialNumber { get; set; }
        public string PlatCode { get; set; }
        public string DateTime { get; set; }
        public string DataType { get; set; }
        public string Units { get; set; }
        public string Status { get; set; }
        public decimal TargetValue { get; set; }
    }
}
