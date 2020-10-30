using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using challenge.Services;
using challenge.Models;

namespace challenge.Controllers
{
    [Route("api/employee/reports")]
    public class ReportingController : Controller
    {
        private readonly ILogger _logger;
        private readonly IReportingStructureService _reportingService;

        public ReportingController(ILogger<EmployeeController> logger, IReportingStructureService reportingService)
        {
            _logger = logger;
            _reportingService = reportingService;
        }

        [HttpGet("{id}", Name = "getReportingStructureById")]
        public IActionResult getReportingStructureById(String id)
        {
            _logger.LogDebug($"Received reporting structure get request for '{id}'");

            var reportingStructure = _reportingService.GetById(id);

            if (reportingStructure == null)
                return NotFound();

            return Ok(reportingStructure);
        }
    }
}
