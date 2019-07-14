using Dal;
using Domain;

namespace CsvFactory
{
    public interface ICsvResolver
    {
        ICsvDal<BaseModel> GetCsvDal(string filename);
    }
}
