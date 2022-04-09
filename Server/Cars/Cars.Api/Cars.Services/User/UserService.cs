using System.Threading.Tasks;
using Cars.IData.User;
using Cars.IServices.Requests;
using Cars.IServices.User;

namespace Cars.Services.User
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Domain.User.User> GetUserByUserId(int userId)
        {
            return _userRepository.GetUser(userId);
        }
        

        public Task<Domain.User.User> GetUserByUserName(string userName)
        {
            return _userRepository.GetUser(userName);
        }

        public async Task<Domain.User.User> CreateUser(CreateUser createUser)
        {
            var user = new Domain.User.User(createUser.UserName, createUser.Email, createUser.Login, createUser.Password);
            user.Id = await _userRepository.AddUser(user);
            return user;
        }

        public async Task EditUser(EditUser createUser, int userId)
        {
            var user = await _userRepository.GetUser(userId);
            user.EditUser(createUser.UserName, createUser.Email, createUser.Login, createUser.Password);
            await _userRepository.EditUser(user);
        }
    }

}