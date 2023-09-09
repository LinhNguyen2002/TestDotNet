namespace TestDotNet.Service.Interface
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        bool Delete(int id);
    }
}
