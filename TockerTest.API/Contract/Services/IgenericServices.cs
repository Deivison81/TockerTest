using TockerTest.API.Contract.Persitence;
using TockerTest.API.Models;
using TockerTest.API.Models.Vmodel;

namespace TockerTest.API.Contract.Services
{
    public interface IGenericServices
    {
        Task<User> CreateServiceAsync(VMUser user);
    }
}
