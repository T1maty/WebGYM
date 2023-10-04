using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebAPI.Models;
using WebAPI.Models.SportClub;
using WebAPI.Models.User;

namespace WebAPI.Service
{
    public class MongoDBService
    {
        private readonly IMongoCollection<SubscriptionService> _subservice;
        private readonly IMongoCollection<CreateUserModel> _createuser;
        private readonly IMongoCollection<CreateSportClubModel> _createsport;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _subservice = database.GetCollection<SubscriptionService>(mongoDBSettings.Value.CollectionName);
            _createuser = database.GetCollection<CreateUserModel>(mongoDBSettings.Value.CollectionName);
            _createsport = database.GetCollection<CreateSportClubModel>(mongoDBSettings.Value.CollectionName);

        }
        public async Task CreateAsync(SubscriptionService subscriptionService) { }
        public async Task AddToAccountAsync(string id, string movieId) { }
        public async Task DeleteAsync(string id) { }
    }
}
