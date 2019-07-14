using System.ComponentModel;

namespace Domain.Enums
{
    public enum DataType
    {
        [Description("Import Wh Total")]
        ImportWhTotal,
        [Description("Import varh Total")]
        ImportVarhTotal,
        [Description("Export Wh Total")]
        ExportWhTotal,
        [Description("Export varh Total")]
        ExportVarhTotal
    }
}
