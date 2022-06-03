using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Praksa_SecondProject.DTO;
using Praksa_SecondProject.Response;
using Praksa_SecondProject.Services.Interfaces;

namespace Praksa_SecondProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _service;

        public AlbumController(IAlbumService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<ServiceResponse<List<GetAlbumDto>>>> Get(int bandId)
        {
            var response=await _service.GetAlbums(bandId);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ServiceResponse<GetAlbumDto>>> GetById(int albumId,int bandId)
        {
            var response = await _service.GetAlbum(bandId,albumId);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<ServiceResponse<GetAlbumDto>>> AddNewAlbum(AddAlbumDto newAlbum)
        {
            var response = await _service.AddAlbum(newAlbum);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPut("[action]/{id}")]
        public async Task<ActionResult<ServiceResponse<GetAlbumDto>>> Update(UpdateAlbumDto updateAlbum)
        {
            var response = await _service.UpdateAlbum(updateAlbum);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ServiceResponse<GetAlbumDto>>> Delete(int albumId)
        {
            var response = await _service.DeleteAlbum(albumId);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
