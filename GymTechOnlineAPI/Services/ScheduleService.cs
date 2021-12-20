using GymTechOnlineAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GymTechOnlineAPI.Services
{
    public class ScheduleService : IService<Session>
    {
        private readonly IMongoCollection<Session> _scheduleCollection;

        public ScheduleService(IOptions<GymTechOnlineDatabaseSettings> gymTechOnlineDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                gymTechOnlineDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                gymTechOnlineDatabaseSettings.Value.DatabaseName);

            _scheduleCollection = mongoDatabase.GetCollection<Session>(
                gymTechOnlineDatabaseSettings.Value.ScheduleCollectionName);
        }

        public async Task<List<Session>> GetAsync() =>
            await _scheduleCollection.Find(_ => true).ToListAsync();

        public async Task<Session?> GetAsync(string id) =>
            await _scheduleCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Session newSession) =>
            await _scheduleCollection.InsertOneAsync(newSession);

        public async Task UpdateAsync(string id, Session updatedSession) =>
            await _scheduleCollection.ReplaceOneAsync(x => x.Id == id, updatedSession);

        public async Task RemoveAsync(string id) =>
            await _scheduleCollection.DeleteOneAsync(x => x.Id == id);

    }
}
