using Domain;
using CsvHelper.Configuration;

namespace Dal.Mappings
{
    public class BaseMap<T> : ClassMap<T> where T : BaseModel
    {
        public BaseMap()
        {
            Map(m => m.MeterPointCode).Name("MeterPoint Code");
            Map(m => m.SerialNumber).Name("Serial Number");
            Map(m => m.PlatCode).Name("Plant Code");
            Map(m => m.DateTime).Name("Date/Time");
            Map(m => m.DataType).Name("Data Type");
            Map(m => m.Units).Name("Units");
            Map(m => m.Status).Name("Status");
            Map(m => m.TargetValue).Name("Data Value","Energy");
        }
    }
}