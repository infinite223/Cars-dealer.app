using System.Threading.Tasks;
using Cars.Api.Mappers;
using Cars.Api.Validation;
using Cars.Data.Sql;
using Cars.IServices.User;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Api.Controllers
{
    [ApiVersion( "2.0" )]
    [Route( "api/v{version:apiVersion}/user" )]
    public class UserV2Controller: Controller
    {
        private readonly CarsDbContext _context;
        private readonly IUserService _userService;

        /// <inheritdoc />
        public UserV2Controller(CarsDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        
        [HttpGet("{userId:min(1)}", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userService.GetUserByUserId(userId);
            if (user != null)
            {
                return Ok(UserToUserViewModelMapper.UserToUserViewModel(user));
            }
            return NotFound();
        }
        
        [HttpGet("name/{userName}", Name = "GetUserByUserName")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var user = await _userService.GetUserByUserName(userName);
            if (user != null)
            {
                return Ok(UserToUserViewModelMapper.UserToUserViewModel(user));
            }
            return NotFound();
        }
        
        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] IServices.Requests.CreateUser createUser)
        {
            var user = await _userService.CreateUser(createUser);
            
            return Created(user.Id.ToString(),UserToUserViewModelMapper.UserToUserViewModel(user)) ;
        }
        
        
        [ValidateModel]
        [HttpPatch("edit/{userId:min(1)}", Name = "EditUser")]
        public async Task<IActionResult> EditUser([FromBody] IServices.Requests.EditUser editUser, int userId)
        {
            await _userService.EditUser(editUser, userId);
            
            return NoContent();
        }

    }
}