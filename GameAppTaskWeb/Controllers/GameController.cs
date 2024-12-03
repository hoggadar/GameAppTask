using Microsoft.AspNetCore.Mvc;

namespace GameAppTaskWeb.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
