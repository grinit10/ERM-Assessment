using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Domain;
using Services;
using Xunit;

namespace ERMAssessment.Tests.Services
{
    public class MedianServiceTest
    {
        private readonly IList<MedianModel> _evenRecs;
        private readonly IList<MedianModel> _oddRecs;
        public MedianServiceTest()
        {
            _evenRecs = new List<MedianModel>()
            {
                new MedianModel{ DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture), Value = 0},
                new MedianModel{ DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture), Value = 1},
                new MedianModel{ DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture), Value = 2},
                new MedianModel{ DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture), Value = 3},
                new MedianModel{ DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture), Value = 4},
                new MedianModel{ DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture), Value = 5}
            };

            _oddRecs = new List<MedianModel>()
            {
                new MedianModel{ DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture), Value = 0},
                new MedianModel{ DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture), Value = 1},
                new MedianModel{ DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture), Value = 2},
                new MedianModel{ DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture), Value = 3},
                new MedianModel{ DateTime = DateTime.Now.ToString(CultureInfo.InvariantCulture), Value = 4},
            };
        }

        [Fact]
        public void ReturnCorrectDateWithEvenNumberOfRecords()
        {
            var result = new MedianService().GetRanges(_evenRecs);
            Assert.Equal(6,result.Count);
            Assert.Equal((decimal)2.5, result.FirstOrDefault()?.MedianValue);
        }

        [Fact]
        public void ReturnCorrectDateWithOddNumberOfRecords()
        {
            var result = new MedianService().GetRanges(_oddRecs);
            Assert.Equal(5, result.Count);
            Assert.Equal(2, result.FirstOrDefault()?.MedianValue);
        }
    }
}
