
using Microsoft.AspNetCore.Mvc;
using YgoData.DataCommand.Interface;
using YgoData.DataQuery.Interface;
using YgoLogic.FactoryUser.Creator;
using YgoModel;

namespace YgoApiAzure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserCommand _userCommand;
        private readonly IUserQuery _userQuery;

        public UserController(IUserCommand userCommand, IUserQuery userQuery)
        {
            _userCommand = userCommand;
            _userQuery = userQuery;
        }

        [HttpPost("UserInsert")]
        public IActionResult UserInsert(UserDto user)
        {
            try
            {
                return Ok(new UserCreator(_userCommand, _userQuery).UserInsert(user));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("UserDataByIdFireBaseGet")]
        public IActionResult UserDataByIdFireBaseGet(string IdFireBase)
        {
            try
            {
                return Ok(new UserCreator(_userCommand, _userQuery).UserDataByIdFireBaseGet(IdFireBase));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
