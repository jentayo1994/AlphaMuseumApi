using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AlphaMuseumApi.DbContext
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbOptions> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _database = mongoClient.GetDatabase("museum");
        }
        public IMongoCollection<Action> Actions => _database.GetCollection<Action>("Action");
        public IMongoCollection<Article> Articles => _database.GetCollection<Article>("Article");
        public IMongoCollection<Event> Events => _database.GetCollection<Event>("Event");
        public IMongoCollection<HistoryEvent> HistoryEvents => _database.GetCollection<HistoryEvent>("HEvent");
    }
}
