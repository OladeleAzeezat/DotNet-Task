using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add Cosmos DB service to the container.
builder.Services.AddSingleton((provider) =>
{
    var endpointUri = configuration["CosmosDbSettings:EndpointUri"];
    var primaryKey = configuration["CosmosDbSettings:PrimaryKey"];
    var databaseName = configuration["CosmosDbSettings:DatabaseName"];

    //var cosmosSettings = configuration.GetSection("DotNetTestDb");
    //var cosmosEndpoint = cosmosSettings.GetValue<string>("Endpoint");
    //var cosmosKey = cosmosSettings.GetValue<string>("Key");

    var cosmosClientOptions = new CosmosClientOptions
    {
        ApplicationName = databaseName
        //    ConnectionMode = ConnectionMode.Direct,
        //    SerializerOptions = new CosmosSerializationOptions
        //    {
        //        PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
        //    }
    };

    var loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    });


    var cosmosClient = new CosmosClient(endpointUri, primaryKey, cosmosClientOptions);
    cosmosClient.ClientOptions.ConnectionMode = ConnectionMode.Direct;
    return cosmosClient;
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
