using AutoMapper;
using Dummy.Models.Domain;
using Dummy.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await regionRepository.GetAllAsync();
            //var regionsDTO = new List<Models.DTO.Region>();
            //regions.ToList().ForEach(region =>
            //{
            //    var regionDTO = new Models.DTO.Region()
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //        Code = region.Code,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population,
            //    };

            //    regionsDTO.Add(regionDTO);
            //});

            //var regions = new List<Region>()
            //{
            //new Region
            //{
            //    Id=5,
            //    Code="wlg",
            //    Name="wellington",
            //    Area=227755,
            //    Lat=-1.88,
            //    Long=299.88,
            //    Population=50000
            //},
            //new Region
            //{
            //  Id=6,
            //    Code="falk",
            //    Name="falkland",

            //    Area=227755,
            //    Lat=-1.88,
            //    Long=299.88,
            //    Population=50000
            //}


            //};
            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDTO);
        }
        [HttpGet]
        [Route("{id:int}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(int id)
        {
            var region = await regionRepository.GetAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);

        }
        //[HttpPost]
        //public async Task<IActionResult> AddRegionAsync(Models.DTO.AddRegionRequest addRegionRequest)

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteRegionAsync(int id)
        {
            var region = await regionRepository.DeleteAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = new Models.DTO.Region()
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population,


            };
            return Ok(regionDTO);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute]int id,[FromBody] Models.DTO.UpdateRegionRequest updateRegionRequest)
        {
            var region = new Models.Domain.Region()
            {
                Code = updateRegionRequest.Code,
                Name = updateRegionRequest.Name,
                Area = updateRegionRequest.Area,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Population = updateRegionRequest.Population,


            };
            var reply = await regionRepository.UpdateAsync(id, region);
            var regionDTO = new Models.DTO.Region()
            {
                Code = reply.Code,
                Name= reply.Name,
                Area= reply.Area,
                Lat= reply.Lat,
                Long= reply.Long,
                Population= reply.Population,

            };
            return Ok(regionDTO);
        }
    }
}
