using System.Threading.Tasks;
using Cars.IData.User;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;

namespace Cars.Data.Sql.User
{
    public class UserRepository: IUserRepository
    {
        private readonly CarsDbContext _context;

        public UserRepository(CarsDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddUser(Domain.User.User user)
        {
            var userDAO =  new DAO.User {
                UserName = user.UserName,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                RegistrationDate = user.CreationDate,
                AdsCount = user.AdsCount,
            };
            await _context.AddAsync(userDAO);
            await _context.SaveChangesAsync();
            return userDAO.UserId;
        }

        public async Task<Domain.User.User> GetUser(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x=>x.UserId == userId);
            return new Domain.User.User(user.UserId,
                user.UserName,
                user.Email,
                user.Login,
                user.Password,
                user.RegistrationDate,
                user.AdsCount);
        }

        public async Task<Domain.User.User> GetUser(string userName)
        {
            var user = await _context.User.FirstOrDefaultAsync(x=>x.UserName == userName);
            return new Domain.User.User(user.UserId,
                user.UserName,
                user.Email,
                user.Login,
                user.Password,
                user.RegistrationDate,
                user.AdsCount);
        }

        public async Task EditUser(Domain.User.User user)
        {
            var editUser = await _context.User.FirstOrDefaultAsync(x=>x.UserId == user.Id);
            editUser.UserName = user.UserName;
            editUser.Email = user.Email;
            editUser.Login = user.Login;
            editUser.Password = user.Password;
            await _context.SaveChangesAsync();
        }
    }
}