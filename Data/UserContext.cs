using MongoDB.Driver;
using SimpleIdentityWithMongoDbApp.Data;
using SimpleIdentityWithMongoDbApp.Data.Interfaces;
using SimpleIdentityWithMongoDbApp.Entities;
using SimpleIdentityWithMongoDbApp.Settings;

public class UserContext : IUserContext
    {
        public UserContext(IIdentityDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Users = database.GetCollection<User>(settings.CollectionName);
            UserContextSeed.SeedData(Users);
        }

        public IMongoCollection<User> Users { get; }
      
    }

