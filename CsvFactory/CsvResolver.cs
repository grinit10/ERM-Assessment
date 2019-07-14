using Dal;
using Domain;

namespace CsvFactory
{
    public class CsvResolver : ICsvResolver
    {
        public CsvResolver(ICsvDal<TouCsv> touDal, ICsvDal<LpCsv> lpDal)
        {
            TouDal = touDal;
            LpDal = lpDal;
        }

        private ICsvDal<LpCsv> LpDal { get; }
        private ICsvDal<TouCsv> TouDal { get; }

        public ICsvDal<BaseModel> GetCsvDal(string filename)
        {
            if (filename.Contains("LP"))
            {
                return LpDal;
            }
            return TouDal;
        }
    }
}
