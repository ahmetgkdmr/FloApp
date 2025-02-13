using ECommerce.Business.Service;
using ECommerce.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;

        public UserTypeController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var UserTypes = _userTypeService.GetAll();
            return Ok(UserTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var UserType = _userTypeService.GetById(id);
            if (UserType == null) return NotFound();
            return Ok(UserType);
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserType userType)
        {
            _userTypeService.Add(userType);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] UserType userType)
        {
            _userTypeService.Update(userType);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userTypeService.Delete(id);
            return Ok();
        }

    }
}
