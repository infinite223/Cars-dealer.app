using System;
using System.Threading.Tasks;
using Cars.Api.BindingModels;
using Cars.Api.Validation;
using Cars.Api.ViewModels;
using Cars.Data.Sql;
using Cars.Data.Sql.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cars.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class UserController : Controller
    {
        private readonly CarsDbContext _context;

        public UserController(CarsDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId:min(1)}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            
            if (user != null)
            {
                return Ok(new UserViewModel
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    UserName = user.UserName,
                    RegistrationDate = user.RegistrationDate, 
                    AdsCount = user.AdsCount,
                });
            }

            return NotFound();
        }

        [HttpGet("name/{userName}", Name = "GetUserByUserName")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user != null)
            {
                return Ok(new UserViewModel
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    UserName = user.UserName,
                    RegistrationDate = user.RegistrationDate, 
                    AdsCount = user.AdsCount,
                });
            }

            return NotFound();
        }

        [ValidateModel]
//        [Consumes("application/x-www-form-urlencoded")]
//        [HttpPost("create", Name = "CreateUser")]
        public async Task<IActionResult> Post([FromBody] CreateUser createUser)
        {
            var user = new User
            {
                Email = createUser.Email,
                UserName = createUser.UserName,
                RegistrationDate = DateTime.UtcNow,
            };
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return Created(user.UserId.ToString(), new UserViewModel
            {
                UserId = user.UserId,
                Email = user.Email,
                UserName = user.UserName,
                RegistrationDate = user.RegistrationDate, 
                AdsCount = user.AdsCount,
            });
        }

        [ValidateModel]
        [HttpPatch("edit/{userId:min(1)}", Name = "EditUser")]
//        public async Task<IActionResult> EditUser([FromBody] EditUser editUser,[FromQuery] int userId)
        public async Task<IActionResult> EditUser([FromBody] EditUser editUser, int userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == userId);
            user.UserName = editUser.UserName;
            user.Email = editUser.Email;
            await _context.SaveChangesAsync();
            return NoContent();
            return Ok(new UserViewModel
            {
                UserId = user.UserId,
                Email = user.Email,
                UserName = user.UserName,
                RegistrationDate = user.RegistrationDate, 
                AdsCount = user.AdsCount,
            });
        }
    }
}