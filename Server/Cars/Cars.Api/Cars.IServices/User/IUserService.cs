using System.Threading.Tasks;
using Cars.IServices.Requests;

namespace Cars.IServices.User
{
    public interface IUserService
    {
        Task<Cars.Domain.User.User> GetUserByUserId(int userId);
        Task<Cars.Domain.User.User> GetUserByUserName(string userName);
        Task<Cars.Domain.User.User> CreateUser(CreateUser createUser);
        Task EditUser(EditUser createUser, int userId);
    }
}