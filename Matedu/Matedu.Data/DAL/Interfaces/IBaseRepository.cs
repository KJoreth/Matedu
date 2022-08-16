namespace Matedu.Data.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task RemoveAsync(T entity);
        Task UpdateAsync(T entity);
    }
}