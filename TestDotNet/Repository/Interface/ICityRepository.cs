using TestDotNet.Entities;

namespace TestDotNet.Repository.Interface
{
    public interface ICityRepository : IRepository<City>
    {
        IEnumerable<City> GetCitiesByName(string cityName);
    }
}
