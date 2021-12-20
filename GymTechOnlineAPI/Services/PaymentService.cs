using GymTechOnlineAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GymTechOnlineAPI.Services
{
    public class PaymentService : IService<Payment>
    {
        private readonly IMongoCollection<Payment> _paymentsCollection;

        public PaymentService(IOptions<GymTechOnlineDatabaseSettings> gymTechOnlineDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                gymTechOnlineDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                gymTechOnlineDatabaseSettings.Value.DatabaseName);

            _paymentsCollection = mongoDatabase.GetCollection<Payment>(
                gymTechOnlineDatabaseSettings.Value.PaymentsCollectionName);
        }

        public async Task<List<Payment>> GetAsync() =>
            await _paymentsCollection.Find(_ => true).ToListAsync();

        public async Task<Payment?> GetAsync(string id) =>
            await _paymentsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Payment newPayment) =>
            await _paymentsCollection.InsertOneAsync(newPayment);

        public async Task UpdateAsync(string id, Payment updatedPayment) =>
            await _paymentsCollection.ReplaceOneAsync(x => x.Id == id, updatedPayment);

        public async Task RemoveAsync(string id) =>
            await _paymentsCollection.DeleteOneAsync(x => x.Id == id);

    }
}
