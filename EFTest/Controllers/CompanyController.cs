using System.Collections.Generic;
using EFTest.Models;
using EFTest.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EFTest.Controllers
{

    [ApiController]
    [Route("/api/v1/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyService _testAService;
        public CompanyController(ILogger<CompanyController> logger, ICompanyService testAService)
        {
            _logger = logger;
            _testAService = testAService;
        }

        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<CompanyStakeholder> Get()
        {
            return _testAService.GetAllCompaniesWithShareholders();
        }
    }
}