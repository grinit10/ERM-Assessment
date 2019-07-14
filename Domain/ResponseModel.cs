using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            FileRecs = new List<FileRec>();
        }
        public string Filename { get; set; }
        public IList<FileRec> FileRecs { get; set; }
    }

    public class FileRec
    {
        public string DateTime { get; set; }
        public decimal Value { get; set; }
        public decimal MedianValue { get; set; }
    }
}
