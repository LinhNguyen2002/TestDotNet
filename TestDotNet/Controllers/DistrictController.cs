using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestDotNet.Entities;
using TestDotNet.Service.Interface;

namespace TestDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<District>> GetAll()
        {
            var districts = _districtService.GetAll();
            return Ok(districts);
        }

        [HttpGet("{id}")]
        public ActionResult<District> GetById(int id)
        {
            var district = _districtService.GetById(id);
            if (district == null)
                return NotFound();

            return Ok(district);
        }

        [HttpPost]
        public ActionResult<District> Add([FromBody] District district)
        {
            var newDistrict = _districtService.Add(district);
            return CreatedAtAction(nameof(GetById), new { id = newDistrict.Id }, newDistrict);
        }

        [HttpPut("{id}")]
        public ActionResult<District> Update(int id, [FromBody] District district)
        {
            if (id != district.Id)
                return BadRequest();

            var updatedDistrict = _districtService.Update(district);
            return Ok(updatedDistrict);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _districtService.Delete(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<District>> SearchByCityId(int cityId)
        {
            var districts = _districtService.GetDistrictsByCityId(cityId);
            return Ok(districts);
        }
    }
}
