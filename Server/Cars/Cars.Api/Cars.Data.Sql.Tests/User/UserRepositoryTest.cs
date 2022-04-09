using System;
using System.Threading.Tasks;
using Cars.Common.Enums;
using Cars.Data.Sql.User;
using Cars.IData.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Cars.Data.Sql.Tests.User
{
    public class UserRepositoryTest
    {
        public IConfiguration Configuration { get; }
        private  CarsDbContext _context;
        private  IUserRepository _userRepository;

        public UserRepositoryTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarsDbContext>();
            optionsBuilder.UseMySQL(
                "server=localhost;userid=root;pwd=;port=3306;database=Cars_db;");
            _context = new CarsDbContext(optionsBuilder.Options);
          
            _userRepository = new UserRepository(_context);
        }
        
        [Fact]
        public async Task AddUser_Returns_Correct_Response()
        {
            var user = new Domain.User.User("Name", "Email", "test3","test" );
            
            var userId = await _userRepository.AddUser(user);
            
            var createdUser = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            Assert.NotNull(createdUser);

            _context.User.Remove(createdUser);
            await _context.SaveChangesAsync();
        }

    }
}