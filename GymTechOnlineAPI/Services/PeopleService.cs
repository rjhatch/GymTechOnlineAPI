using GymTechOnlineAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GymTechOnlineAPI.Services
{
    public class PeopleService : IService<Person>
    {
        private readonly IMongoCollection<Person> _peopleCollection;

        public PeopleService(IOptions<GymTechOnlineDatabaseSettings> gymTechOnlineDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                gymTechOnlineDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                gymTechOnlineDatabaseSettings.Value.DatabaseName);

            _peopleCollection = mongoDatabase.GetCollection<Person>(
                gymTechOnlineDatabaseSettings.Value.PeopleCollectionName);
        }

        public async Task<List<Person>> GetAsync() =>
            await _peopleCollection.Find(_ => true).ToListAsync();

        public async Task<Person?> GetAsync(string id) =>
            await _peopleCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Person newPerson) =>
            await _peopleCollection.InsertOneAsync(newPerson);

        public async Task UpdateAsync(string id, Person updatedPerson) =>
            await _peopleCollection.ReplaceOneAsync(x => x.Id == id, updatedPerson);

        public async Task RemoveAsync(string id) =>
            await _peopleCollection.DeleteOneAsync(x => x.Id == id);

    }
}
