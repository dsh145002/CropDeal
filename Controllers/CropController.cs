using CaseStudy.Dtos;
using CaseStudy.Models;
using CaseStudy.Services;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CropController : ControllerBase
    {
        private readonly CropService _service;
        public CropController(CropService service)
        {
            _service = service;
        }

        [HttpPost("addCrop/fid")]
        public async Task<ActionResult<CropDetail>> AddNewCrop(AddCropDto crop ,int fid)
        {

            var res = await _service.AddCropAsync(crop,fid);
            if (res == null)
            {
                return BadRequest("Error while adding crop details");
            }
            return Ok(res);

        }

        [HttpGet("getCrops")]
        public async Task<ActionResult<IEnumerable<CropDetail>>> GetAllCrops()
        {
            var res = await _service.GetAllCropAsync();
            if(res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpGet("getCrops/id")]
        public async Task<ActionResult<CropDetail>> GetCropById(int id)
        {
            var res = await _service.GetCropByIdAsync(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

    }
}
