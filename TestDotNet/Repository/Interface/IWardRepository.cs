using TestDotNet.Entities;

namespace TestDotNet.Repository.Interface
{
    public interface IWardRepository : IRepository<Ward>
    {
        IEnumerable<Ward> GetWardsByDistrictId(int districtId);
    }
}
