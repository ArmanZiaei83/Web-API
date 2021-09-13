using System.ComponentModel.DataAnnotations;
using Entities.user;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace FirstAPI.Controllers.AddUser
{
    [ApiController]
    [Route("[controller]")]
    public class UserAdd : Controller
    {
        private UnitOfWork _unitOfWork = new();

        [HttpPost]
        public IActionResult Index([Required] string userName, [Required] string userEmail,
            [Required] string userPassword)
        {
            _unitOfWork.UserRepository.Add(new User()
            {
                UserName = userName,
                UserEmail = userEmail,
                UserPassword = userPassword
            });
            _unitOfWork.Save();
            return Ok();
        }
    }
}