using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace FirstAPI.Controllers.Update
{
    [ApiController]
    [Route("[controller]")]
    public class PutUser : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        [HttpPut]
        public IActionResult Index([Required] int id, [Required] string name, [Required] string email,
            [Required] string password)
        {
            if (!unitOfWork.UserRepository.Exists(id)) return NotFound();
            unitOfWork.UserRepository.PutUpdate(id, name, email, password);
            unitOfWork.Save();
            return Ok("Updated ...");

        }
    }
}