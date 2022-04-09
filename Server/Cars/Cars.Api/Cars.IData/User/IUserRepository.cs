using System.Threading.Tasks;

namespace Cars.IData.User
{
    public interface IUserRepository
    {
        Task<int> AddUser(Cars.Domain.User.User user);
        Task<Cars.Domain.User.User> GetUser(int userId);
        Task<Cars.Domain.User.User> GetUser(string userName);
        Task EditUser(Domain.User.User user);
    }
}