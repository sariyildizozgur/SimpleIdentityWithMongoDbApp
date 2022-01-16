using MongoDB.Driver;
using SimpleIdentityWithMongoDbApp.Entities;

namespace SimpleIdentityWithMongoDbApp.Data
{
    public class UserContextSeed
    {
        public static void SeedData(IMongoCollection<User> userCollection)
        {
            var existProduct = userCollection.Find(p => true).Any();
            if (!existProduct)
            {
                userCollection.InsertManyAsync(GetConfigureUser());
            }
        }

        private static IEnumerable<User> GetConfigureUser()
        {
            return new List<User>() { new User { UserName = "ozgur", Email = "ozgur@gmail.com", Password = "1234" } };
        }
    }
}