using System;
using System.Collections.Generic;
using System.Linq;
using CsvFactory;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;

namespace ERMAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly ICsvResolver _csvResolver;
        private readonly IMedianService _medianService;
        private readonly ILogger _logger;


        public FilesController(ICsvResolver csvResolver,
            IMedianService medianService,
            ILogger<FilesController> logger)
        {
            _csvResolver = csvResolver;
            _medianService = medianService;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok("I am okay");
        }

        [HttpPost]
        //[Consumes("application/json", "application/json-patch+json", "multipart/form-data")]
        public IActionResult ProcessFiles(List<IFormFile> files)
        {
            var responseRecs = new List<ResponseModel>();
            _logger.LogInformation("Files count: " + files.Count);
            files.ForEach(f =>
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
            _logger.LogInformation("responseRecs: " + responseRecs);
            return Ok(responseRecs);
        }
    }
}