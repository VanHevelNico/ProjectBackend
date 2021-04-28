using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Project.Controllers
{
    [ApiController]
    [Route("api")]
    public class BackendApiController : ControllerBase
    {
        private  IBackendProjectService _backendProjectService;
        private readonly ILogger<BackendApiController> _logger;

        public BackendApiController(ILogger<BackendApiController> logger, IBackendProjectService backendProjectService)
        {
            _logger = logger;
            _backendProjectService = backendProjectService;
        }

        [HttpGet]
        [Route("cafes")]
        public async Task<ActionResult<List<Cafe>>> GetCafes() {
            try {
                return new OkObjectResult(await _backendProjectService.GetCafes());

            }
            catch(Exception ex) {
                Console.WriteLine(ex);
                // return new StatusCodeResult(500);
                return new OkObjectResult(ex);

            }
        }
    }
}
