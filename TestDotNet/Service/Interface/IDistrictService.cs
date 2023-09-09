using TestDotNet.Entities;

namespace TestDotNet.Service.Interface
{
    public interface IDistrictService : IService<District>
    {
        IEnumerable<District> GetDistrictsByCityId(int cityId);
    }
}
