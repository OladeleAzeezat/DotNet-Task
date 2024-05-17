using DotNetTask.Data;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace DotNetTask.Service
{
    public class Users : IUser
    {
        private readonly CosmosClient cosmosClient;
        private readonly IConfiguration configuration;
        private readonly Container _userContainer;

        public Users(CosmosClient cosmosClient, IConfiguration configuraation)
        {
            this.cosmosClient = cosmosClient;
            this.configuration = configuraation;
            var databaseName = configuration["CosmosDbSettings:DatabaseName"];
            var userContainerName = "User";
            _userContainer = cosmosClient.GetContainer(databaseName, userContainerName);
        }

        public async Task<IEnumerable<Models.User>> GetUser(string id)
        {
            try
            {
                var query = _userContainer.GetItemLinqQueryable<User>()
                        .Where(x => x.Id == id)
                        .ToFeedIterator();
                var use = new List<User>();

                while (query.HasMoreResults)
                {
                    var response = await query.ReadNextAsync();
                    use.AddRange(response);
                }

                return (IEnumerable<Models.User>)use;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
