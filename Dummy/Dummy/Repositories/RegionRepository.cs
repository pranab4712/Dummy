using Dummy.Data;
using Dummy.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dummy.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly ApplicationDbContext _db;
        public RegionRepository(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public async Task<Region> AddAsync(Region region)
        {
            //region.Id = 3;
            await _db.Regions.AddAsync(region);
            await _db.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(int id)
        {
            var region= await _db.Regions.FirstOrDefaultAsync(x => x.Id == id);
            _db.Remove(region);
            _db.SaveChangesAsync();
            return region;

        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _db.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(int id)
        {
            return await _db.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateAsync(int id, Region region)
        {
           var existingRegion=await _db.Regions.FirstOrDefaultAsync(x => x.Id == id);
            existingRegion.Code=region.Code;
            existingRegion.Name=region.Name;
            existingRegion.Area=region.Area;
            existingRegion.Lat=region.Lat;
            existingRegion.Long=region.Long;
            existingRegion.Population=region.Population;
            await _db.SaveChangesAsync();
            return existingRegion;
        }
    }
}
