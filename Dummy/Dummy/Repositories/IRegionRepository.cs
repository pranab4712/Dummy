using Dummy.Models.Domain;

namespace Dummy.Repositories
{
    public interface IRegionRepository
    {
       Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetAsync(int id);
        Task<Region> AddAsync(Region region);
        Task<Region> DeleteAsync(int id);
        Task<Region> UpdateAsync(int id, Region region);    
    }
}
