using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FictionFactoryExample2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860



namespace FictionFactoryExample2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DrawingService _drawingService;

        public ValuesController(DrawingService drawingService)
        {
            _drawingService = drawingService;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            var drawingsEntity = _drawingService.Get(id);

            if (drawingsEntity == null)
            {
                return "not found";
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(drawingsEntity);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public Models.DrawingsEntity Post(Models.DrawingsEntity drawingEntity)
        {
            _drawingService.Create(drawingEntity);

            return drawingEntity;

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
