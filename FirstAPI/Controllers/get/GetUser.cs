using Microsoft.AspNetCore.Mvc;
using Services;

namespace FirstAPI.Controllers.Get
{
    [ApiController]
    [Route("[controller]")]
    public class GetUser : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_unitOfWork.UserRepository.GetAll());
        }
    }
}