using Domain;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Dal
{
    public interface ICsvDal<out T> where T : BaseModel
    {
        IEnumerable<T> ReadCsv(IFormFile file);
    }
}
