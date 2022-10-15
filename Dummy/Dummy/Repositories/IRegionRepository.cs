using Dummy.Models.Domain;

namespace Dummy.Repositories
{
    public interface IRegionRepository
    {
       Task<IEnumerable<Region>> GetAllAsync();
    }
}
