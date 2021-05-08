using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using server.Entities;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShinobiCardController : ControllerBase
    {
        private readonly ILogger<ShinobiCardController> _logger;

        public ShinobiCardController(ILogger<ShinobiCardController> logger)
        {
            _logger = logger;
        }

        /*[HttpGet]
        public IEnumerable<ShinobiCard> Get()
        {
            return
        }*/
    }
}
