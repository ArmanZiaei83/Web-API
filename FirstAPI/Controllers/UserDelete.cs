using Microsoft.AspNetCore.Mvc;
using Services;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDelete : Controller
    {
        private readonly UnitOfWork _unitOfWork = new();

        [HttpDelete("{id:int}")]
        public IActionResult Index(int id)
        {
            if (!_unitOfWork.UserRepository.Exists(id).Result) return NotFound();
            _unitOfWork.UserRepository.DeleteById(id);
            _unitOfWork.Save();
            return Ok();
        }
    }
}