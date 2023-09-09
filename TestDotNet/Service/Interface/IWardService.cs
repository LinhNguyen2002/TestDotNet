using TestDotNet.Entities;

namespace TestDotNet.Service.Interface
{
    public interface IWardService : IService<Ward>
    {
        IEnumerable<Ward> GetWardsByDistrictId(int districtId);
    }
}
