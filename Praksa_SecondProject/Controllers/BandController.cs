using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Praksa_SecondProject.DTO;
using Praksa_SecondProject.Helpers;
using Praksa_SecondProject.Response;
using Praksa_SecondProject.Services.Interfaces;

namespace Praksa_SecondProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandController : ControllerBase
    {
        private readonly IBandService _service;

        public BandController(IBandService service)
        {
            _service = service;
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<ServiceResponse<List<GetBandDto>>>> GetAll()
        {
            var response = await _service.GetBands();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<ServiceResponse<List<GetBandDto>>>> GetBandsByGenre([FromQuery] BandResourceParameters search )
        {
            var response = await _service.GetBandsByGenre(search);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ServiceResponse<GetBandDto>>> GetById(int id)
        {
            var response = await _service.GetBandById(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<ServiceResponse<GetBandDto>>> Add(AddBandDto newBand)
        {
            var response = await _service.AddBand(newBand);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<ServiceResponse<GetBandDto>>> Update(UpdateBandDto updateBand)
        {
            var response = await _service.UpdateBand(updateBand);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<ServiceResponse<GetBandDto>>> Delete(int id)
        {
            var response = await _service.DeleteBand(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

    }
}
