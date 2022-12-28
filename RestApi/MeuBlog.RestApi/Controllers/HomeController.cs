using Microsoft.AspNetCore.Mvc;

namespace MeuBlog.RestApi.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {


            return Ok("Teste");
        }
    }
}
