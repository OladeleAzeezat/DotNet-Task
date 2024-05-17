using DotNetTask.Models;

namespace DotNetTask.Data
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetUser(string id);
    }
}
