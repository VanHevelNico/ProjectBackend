using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Project.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class BackendApiController : ControllerBase
    {
        private  IBackendProjectService _backendProjectService;
        private readonly ILogger<BackendApiController> _logger;

        private IMapper _mapper;

        public BackendApiController(IMapper mapper,ILogger<BackendApiController> logger, IBackendProjectService backendProjectService)
        {
            _logger = logger;
            _mapper = mapper;
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
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("cafes/{cafeId}")]
        public async Task<ActionResult<Cafe>> GetCafeById(Guid cafeId) {
            try {
                return new OkObjectResult(await _backendProjectService.GetCafeById(cafeId));

            }
            catch(Exception ex) {
                Console.WriteLine(ex);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [Route("cafes")]
        public async Task<ActionResult<CafeDTO>> AddCafe(CafeDTO cafe)
        {
            try{
                return new OkObjectResult(await _backendProjectService.AddCafe(cafe));
            }
            catch(Exception ex){
                Console.WriteLine(ex);
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("evenementen")]
        public async Task<ActionResult<List<Evenementen>>> GetEvenementen() {
            try {
                return new OkObjectResult(await _backendProjectService.GetEvenementen());

            }
            catch(Exception ex) {
                Console.WriteLine(ex);
                // return new StatusCodeResult(500);
                return new OkObjectResult(ex);

            }
        }
    }
}
