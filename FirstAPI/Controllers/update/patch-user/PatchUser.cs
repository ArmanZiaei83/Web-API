using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace FirstAPI.Controllers.update.patch_user
{
    [ApiController]
    [Route("[controller]")]
    public class PatchUser : Controller
    {
        private UnitOfWork _unitOfWork = new();

        [HttpPatch]
        public IActionResult Index([Required] int id, string name, string password, string email)
        {
            if (!_unitOfWork.UserRepository.Exists(id)) return NotFound();
            _unitOfWork.UserRepository.PatchUpdate(id, name, password,email);
            _unitOfWork.Save();
            return Ok("Updated ... ");

        }
    }
}