using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestDotNet.Entities;
using TestDotNet.Service.Interface;

namespace TestDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<City>> GetAll()
        {
            var cities = _cityService.GetAll();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public ActionResult<City> GetById(int id)
        {
            var city = _cityService.GetById(id);
            if (city == null)
                return NotFound();

            return Ok(city);
        }

        [HttpPost]
        public ActionResult<City> Add([FromBody] City city)
        {
            var newCity = _cityService.Add(city);
            return CreatedAtAction(nameof(GetById), new { id = newCity.Id }, newCity);
        }

        [HttpPut("{id}")]
        public ActionResult<City> Update(int id, [FromBody] City city)
        {
            if (id != city.Id)
                return BadRequest();

            var updatedCity = _cityService.Update(city);
            return Ok(updatedCity);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _cityService.Delete(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<City>> SearchByName(string cityName)
        {
            var cities = _cityService.GetCitiesByName(cityName);
            return Ok(cities);
        }
    }
}
