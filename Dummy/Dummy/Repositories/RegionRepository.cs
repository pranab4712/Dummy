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
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _db.Regions.ToListAsync();
        }
    }
}
