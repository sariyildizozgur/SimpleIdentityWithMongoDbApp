namespace SimpleIdentityWithMongoDbApp.Settings
{
   public interface IIdentityDbSettings{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string CollectionName { get; set; }
}
}
