using System;
using System.Collections.Generic;
using System.Linq;
using CsvFactory;
using Dal;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ERMAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly ICsvResolver _csvResolver;
        private readonly IMedianService _medianService;

        public FilesController(ICsvResolver csvResolver, IMedianService medianService)
        {
            _csvResolver = csvResolver;
            _medianService = medianService;
        }

        [HttpPost]
        [Consumes("application/json", "application/json-patch+json", "multipart/form-data")]
        public IActionResult ProcessFiles(List<IFormFile> files)
        {
            var responseRecs = new List<ResponseModel>();
            files.ForEach(f=>
            {
                var result = _csvResolver.GetCsvDal(f.FileName).ReadCsv(f);
                var records = _medianService.GetRanges(result.Select(r => new MedianModel
                {
                    DateTime = r.DateTime,
                    Value = r.TargetValue
                }).ToList());
                responseRecs.Add(new ResponseModel()
                {
                    FileRecs = records,
                    Filename = f.FileName
                });
            });
            return Ok(responseRecs);
        }
    }
}