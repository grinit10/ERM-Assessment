using Domain;

namespace Dal.Mappings
{
    public sealed class LpMap : BaseMap<LpCsv>
    {
        public LpMap()
        {
            Map(m => m.DataValue).Name("Data Value");
        }
    }
}
