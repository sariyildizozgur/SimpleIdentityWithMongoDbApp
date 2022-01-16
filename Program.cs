using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using SimpleIdentityWithMongoDbApp;
using SimpleIdentityWithMongoDbApp.Data.Interfaces;
using SimpleIdentityWithMongoDbApp.Entities;
using SimpleIdentityWithMongoDbApp.Services;
using SimpleIdentityWithMongoDbApp.Settings;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<IdentityDbSettings>(builder.Configuration.GetSection("IdentityDbSettings"));
builder.Services.AddSingleton<IIdentityDbSettings>(sp => sp.GetRequiredService<IOptions<IdentityDbSettings>>().Value);   



//Identity Config

builder.Services.AddIdentityServer(options =>
            {
                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            })
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients)
                .AddResourceOwnerValidator<IdentityResourceOwnerPasswordValidator>() //UserName && Password control
                .AddDeveloperSigningCredential(); //Test 3




//Identity End



builder.Services.AddTransient<IUserContext,UserContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


 app.UseIdentityServer();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// app.MapGet("/", () => "Hello, ASOS!");

app.Run();

