using MeuBlog.Shared.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MeuBlog.RestApi.Controllers
{
    [Route("/Home")]
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Teste");
        }
    }
}
