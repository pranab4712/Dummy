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
        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
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
    }
}
