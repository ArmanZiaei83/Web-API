using Entities.user;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAdd : Controller
    {
        private readonly UnitOfWork _unitOfWork = new();

        [HttpPost]
        public IActionResult Index(User user)
        {
            var myUser = new User
            {
                UserEmail = user.UserEmail,
                UserName = user.UserName,
                UserId = user.UserId,
                UserPassword = user.UserPassword
            };
            _unitOfWork.UserRepository.Add(myUser);
            _unitOfWork.Save();
            return Ok("Added ...");
        }
    }
}