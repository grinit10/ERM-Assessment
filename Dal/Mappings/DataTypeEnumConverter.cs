using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Domain.Enums;

namespace Dal.Mappings
{
    internal class DataTypeEnumConverter : EnumConverter, ITypeConverter
    {
        public DataTypeEnumConverter() : base(DataType.ImportWhTotal.GetType())
        {
        }
        public override string ConvertToString(
            object value,
            IWriterRow row,
            MemberMapData memberMapData)
        {
            if (Enum.TryParse<DataType>(value.ToString(), out var result))
            {
                return (Convert.ToInt32(result)).ToString();
            }

            throw new InvalidCastException($"Invalid value to EnumConverter. Type: {typeof(DataType)} Value: {value}");
        }

        public override object ConvertFromString(
            string text,
            IReaderRow row,
            MemberMapData memberMapData)
        {
            if (Enum.TryParse<DataType>(text, out var result))
            {
                return result;
            }

            throw new InvalidCastException($"Invalid value to EnumConverter. Type: {typeof(DataType)} Value: {text}");

        }
    }
}
