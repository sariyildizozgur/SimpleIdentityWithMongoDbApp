using MongoDB.Bson.Serialization.Attributes;

namespace SimpleIdentityWithMongoDbApp.Entities{
public class User {

    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set;}
    public string UserName {get;set;}
    public string Email {get;set;}
    public string Password {get;set;}
 }
}