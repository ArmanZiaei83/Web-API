using Entities.user;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserUpdate : Controller
    {
        private readonly UnitOfWork _unitOfWork = new();

        [HttpPatch]
        public IActionResult Index(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Save();
            return Ok();
        }
    }
}