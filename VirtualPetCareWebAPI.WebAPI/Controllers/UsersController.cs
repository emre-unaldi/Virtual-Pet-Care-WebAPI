using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCareWebAPI.Business.Abstracts;
using VirtualPetCareWebAPI.Entity.Concretes.Requests;

namespace VirtualPetCareWebAPI.WebAPI.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Add(AddUserRequest addUserRequest)
        {
            var result = _userService.Add(addUserRequest);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpPut]
        public IActionResult Update(UpdateUserRequest updateUserRequest)
        {
            var result = _userService.Update(updateUserRequest);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpDelete("{userId}")]
        public IActionResult Delete([FromRoute] int userId)
        {
            var result = _userService.Delete(userId);

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();

            return result.Success ? Ok(result) : BadRequest();
        }

        [HttpGet("{userId}")]
        public IActionResult GetUserById([FromRoute] int userId)
        {
            var result = _userService.GetUserById(userId);

            return result.Success ? Ok(result) : BadRequest();
        }
    }
}

