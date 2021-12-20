using GymTechOnlineAPI.Models;
using MongoDB.Driver;

namespace GymTechOnlineAPI.Services
{
    public interface IService<T> where T : IEntity
    {
        Task<List<T>> GetAsync();

        Task<T?> GetAsync(string id);

        Task CreateAsync(T newPerson);

        Task UpdateAsync(string id, T updatedPerson);

        Task RemoveAsync(string id);
    }
}
