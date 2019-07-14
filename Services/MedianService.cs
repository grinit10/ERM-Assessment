using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Services
{
    public class MedianService : IMedianService
    {
        private static decimal GetMedian(ICollection<decimal> values)
        {
            var numberCount = values.Count;
            var halfIndex = values.Count / 2;
            var sortedNumbers = values.OrderBy(n => n);
            decimal median;
            if (numberCount % 2 == 0)
            {
                var middleElement1 = sortedNumbers.ElementAt(halfIndex - 1);
                var middleElement2 = sortedNumbers.ElementAt(halfIndex);

                median = (middleElement1 + middleElement2) / 2;
            }
            else
            {
                median = sortedNumbers.ElementAt(halfIndex);
            }

            return median;
        }

        public IList<FileRec> GetRanges(IList<MedianModel> recs)
        {
            var median = GetMedian(recs.Select(r => r.Value).ToList());
            return recs.Where(r => r.Value <= median *  (decimal) 1.02 || 
                                   r.Value >= median *  (decimal) 0.8)
                .Select(i => new FileRec
                {
                    Value = i.Value,
                    DateTime = i.DateTime,
                    MedianValue = median
                })
                .ToList();
        }
    }
}
