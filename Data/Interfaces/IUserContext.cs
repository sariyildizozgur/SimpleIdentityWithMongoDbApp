using MongoDB.Driver;
using SimpleIdentityWithMongoDbApp.Entities;

namespace SimpleIdentityWithMongoDbApp.Data.Interfaces{
public interface IUserContext
{
        IMongoCollection<User> Users { get;  }
}
}

