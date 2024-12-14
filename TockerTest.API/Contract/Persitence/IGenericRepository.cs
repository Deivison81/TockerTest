namespace TockerTest.API.Contract.Persitence
{
    public interface IGenericRepository<T>where T : class
    {
        Task<T> CreateAsync(T entity);

        Task<T> SentAsync(T entity);
    }
}
