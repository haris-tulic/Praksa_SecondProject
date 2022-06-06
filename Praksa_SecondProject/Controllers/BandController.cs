using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Praksa_SecondProject.DTO;
using Praksa_SecondProject.Helpers;
using Praksa_SecondProject.Response;
using Praksa_SecondProject.Services.Interfaces;
using System.Text.Json;

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
        
        [HttpGet("[action]")]
        [HttpHead]
        public PageList<GetBandDto> GetBandsPerPage(BandResourceParameters parameters)
        {
            var response=_service.GetBandsPerPage(parameters);
            var previousPageLink = response.HasPrevious ? CreateBandsUri(parameters, UriType.PreviousPage) : null;
            var nextPageLink = response.HasNext ? CreateBandsUri(parameters, UriType.NextPage) : null;
            var metaData = new
            {
                totalCount = response.TotatCount,
                pageSize = response.PageSize,
                currentPage = response.CurrentPage,
                totalPage = response.TotalPages,
                previousPageLink,
                nextPageLink,
            };
            Response.Headers.Add("Pagination", JsonSerializer.Serialize(metaData));
            return response;
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
        [HttpPut("[action]")]
        public async Task<ActionResult<ServiceResponse<GetBandDto>>> Update(UpdateBandDto updateBand)
        {
            var response = await _service.UpdateBand(updateBand);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<ServiceResponse<GetBandDto>>> Delete(int id)
        {
            var response = await _service.DeleteBand(id);
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        private  string CreateBandsUri(BandResourceParameters bandResourceParameters,UriType type)
        {
            switch (type)
            {
                case UriType.PreviousPage:
                    return Url.Link("GetBandsPerPage", new
                    {
                        pageNumber=bandResourceParameters.PageNumber-1,
                        pageSize=bandResourceParameters.PageSize,
                        mainGenre=bandResourceParameters.Genre,
                        searchQuery=bandResourceParameters.SearchQuery,
                    });
                case UriType.NextPage:
                    return Url.Link("GetBandsPerPage", new
                    {
                        pageNumber = bandResourceParameters.PageNumber + 1,
                        pageSize = bandResourceParameters.PageSize,
                        mainGenre = bandResourceParameters.Genre,
                        searchQuery = bandResourceParameters.SearchQuery,
                    });
                default:
                    return Url.Link("GetBandsPerPage", new
                    {
                        pageNumber = bandResourceParameters.PageNumber,
                        pageSize = bandResourceParameters.PageSize,
                        mainGenre = bandResourceParameters.Genre,
                        searchQuery = bandResourceParameters.SearchQuery,
                    }); ;
            }
        }
        //public List<LinkDto> CreateLinkList(int id,string fields)
        //{
        //    var listLinks=new List<LinkDto>();
        //    if (string.IsNullOrWhiteSpace(fields))
        //    {
        //        listLinks.Add(new LinkDto(Url.Link("GetAll", null), "self", "GET"));
        //    }
        //    listLinks.Add(new LinkDto(Url.Link("Delete", new { id }), "delete_band", "DELETE"));

        //    return listLinks;
        //}
    }
}
