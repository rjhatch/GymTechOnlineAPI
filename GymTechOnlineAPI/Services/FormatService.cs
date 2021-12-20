using GymTechOnlineAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;


namespace GymTechOnlineAPI.Services
{
    public class FormatService : IService<FormatDocument>
    {
        private readonly IMongoCollection<FormatDocument> _formatCollection;

        public FormatService(IOptions<GymTechOnlineDatabaseSettings> gymTechOnlineDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                gymTechOnlineDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                gymTechOnlineDatabaseSettings.Value.DatabaseName);

            _formatCollection = mongoDatabase.GetCollection<FormatDocument>(
                gymTechOnlineDatabaseSettings.Value.FormatCollectionName);
        }

        public async Task<List<FormatDocument>> GetAsync() =>
            await _formatCollection.Find(_ => true).ToListAsync();

        public async Task<FormatDocument?> GetAsync(string document) =>
            await _formatCollection.Find(x => x.DocumentName == document).FirstOrDefaultAsync();

        public async Task CreateAsync(FormatDocument newFormatDocument) =>
            await _formatCollection.InsertOneAsync(newFormatDocument);

        public async Task UpdateAsync(string id, FormatDocument updatedFormatDocument) =>
            await _formatCollection.ReplaceOneAsync(x => x.Id == id, updatedFormatDocument);

        public async Task RemoveAsync(string id) =>
            await _formatCollection.DeleteOneAsync(x => x.Id == id);

    }
}
