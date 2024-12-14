using TockerTest.API.Contract.Persitence;
using TockerTest.API.Models;

namespace TockerTest.API.persistence.Repository
{
    public class GenericRepository : IGenericRepository<User>
    {
        private readonly TockenDbcontext _dbcontext;

        public GenericRepository(TockenDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<User> CreateAsync(User entity)
        {
           
           await _dbcontext.AddAsync(entity);
           await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public Task<User> SentAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
