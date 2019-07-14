using System.Collections.Generic;
using Domain;

namespace Services
{
    public interface IMedianService
    {
        IList<FileRec> GetRanges(IList<MedianModel> recs);
    }
}
