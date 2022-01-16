
using SimpleIdentityWithMongoDbApp.Settings;

namespace SimpleIdentityWithMongoDbApp.Settings
{

public class IdentityDbSettings : IIdentityDbSettings
{
    public string ConnectionString { get; set;}
    public string DatabaseName { get;set; }
    public string CollectionName { get;set; }
}

}

