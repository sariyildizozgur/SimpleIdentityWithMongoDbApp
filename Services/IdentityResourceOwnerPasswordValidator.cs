using IdentityModel;
using IdentityServer4.Validation;
using MongoDB.Bson;
using MongoDB.Driver;
using SimpleIdentityWithMongoDbApp.Data.Interfaces;
using SimpleIdentityWithMongoDbApp.Entities;

namespace SimpleIdentityWithMongoDbApp.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {

         private readonly IUserContext _userContext;

        public IdentityResourceOwnerPasswordValidator(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
           var existUser = await _userContext.Users.Find(x=>  x.UserName == context.UserName && x.Password == context.Password).FirstOrDefaultAsync();

        //    //Alternative Search 2 -not tested
        //    var filterBuilder = new FilterDefinitionBuilder<User>();
        //    var filter = filterBuilder.Eq(s => s.UserName, context.UserName) & filterBuilder.Eq(s => s.Password, context.Password);
        //    var result = await _userContext.Users.Find(filter).FirstOrDefaultAsync();
           
        //    //Alternative Search 3 - not tested
        //    var filterBson = BsonDocument.Parse(@"{{ UserName: { $eq: ozgur ,{ Password: { $eq: 1234 }}}");      
        //    var result2 = await _userContext.Users.Find(filterBson).FirstOrDefaultAsync(); 
            
            if (existUser == null)
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string> { "Invalid email and password" });
                context.Result.CustomResponse = errors;

                return;
            }

            context.Result = new GrantValidationResult(existUser.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
            
        }

       
    }
}