using TockerTest.API.Contract.Persitence;
using TockerTest.API.Contract.Services;
using TockerTest.API.Models;
using TockerTest.API.Models.Vmodel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TockerTest.API.Services
{

    public class UserServices : IGenericServices
    {
        private readonly IGenericRepository<User> _repo;

        public UserServices(IGenericRepository<User> repo)
        {
            _repo = repo;
        }

        public async Task<User> CreateServiceAsync(VMUser entity)
        {
            var newdata = new User
            {
                Id = Guid.NewGuid(),
                Phone = entity.Phone,
                UserName = entity.UserName,
            };

            return await _repo.CreateAsync(newdata);

        }

        
    }
}
