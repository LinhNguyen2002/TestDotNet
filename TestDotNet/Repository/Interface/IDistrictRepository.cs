using TestDotNet.Entities;

namespace TestDotNet.Repository.Interface
{
    public interface IDistrictRepository : IRepository<District>
    {
        IEnumerable<District> GetDistrictsByCityId(int cityId);
    }
}
