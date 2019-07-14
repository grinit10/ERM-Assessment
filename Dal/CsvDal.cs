using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Dal.Mappings;
using Domain;
using Microsoft.AspNetCore.Http;

namespace Dal
{
    public class CsvDal<T> : ICsvDal<T> where T: BaseModel
    {
        public IEnumerable<T> ReadCsv(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.RegisterClassMap<BaseMap<T>>();
                var result = csv.GetRecords<T>();
                return result.ToArray();
            }
        }
    }
}
