using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace FirstAPI.Controllers.Delete
{
    [ApiController]
    [Route("[controller]")]
    public class DeleteUser : Controller
    {
        private UnitOfWork _unitOfWork = new();

        [HttpDelete]
        public IActionResult Index([Required] int id)
        {
            if (!_unitOfWork.UserRepository.Exists(id)) return NotFound();
            _unitOfWork.UserRepository.DeleteById(id);
            _unitOfWork.Save();
            return Ok("Deleted");
        }
    }
}