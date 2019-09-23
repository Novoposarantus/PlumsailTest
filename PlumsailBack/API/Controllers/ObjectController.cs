using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Domain.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectController : ControllerBase
    {
        private readonly IObjectRepository _repository;

        public ObjectController(IObjectRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _repository.GetObjects());
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]JObject json)
        {
            return Ok(await _repository.SaveObject(JsonToValues.Parse(json)));
        }
    }
}
