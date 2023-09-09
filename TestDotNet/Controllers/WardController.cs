using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestDotNet.Entities;
using TestDotNet.Service.Interface;

namespace TestDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : ControllerBase
    {
        private readonly IWardService _wardService;

        public WardController(IWardService wardService)
        {
            _wardService = wardService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ward>> GetAll()
        {
            var wards = _wardService.GetAll();
            return Ok(wards);
        }

        [HttpGet("{id}")]
        public ActionResult<Ward> GetById(int id)
        {
            var ward = _wardService.GetById(id);
            if (ward == null)
                return NotFound();

            return Ok(ward);
        }

        [HttpPost]
        public ActionResult<Ward> Add([FromBody] Ward ward)
        {
            var newward = _wardService.Add(ward);
            return CreatedAtAction(nameof(GetById), new { id = newward.Id }, newward);
        }

        [HttpPut("{id}")]
        public ActionResult<Ward> Update(int id, [FromBody] Ward ward)
        {
            if (id != ward.Id)
                return BadRequest();

            var updatedward = _wardService.Update(ward);
            return Ok(updatedward);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _wardService.Delete(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Ward>> SearchByCityId(int cityId)
        {
            var wards = _wardService.GetWardsByDistrictId(cityId);
            return Ok(wards);
        }
    }
}
