using Microsoft.AspNetCore.Mvc;
using Services;

namespace FirstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetUser : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new UnitOfWork().UserRepository.GetAll().Result);
        }
    }
}