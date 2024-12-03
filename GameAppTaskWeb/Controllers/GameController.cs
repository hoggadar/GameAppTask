using GameAppTaskBusiness.DTOs.BoardGame;
using Microsoft.AspNetCore.Mvc;

namespace GameAppTaskWeb.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateBoardGameDto dto)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id, UpdateBoardGameDto dto)
        {
            return View();
        }

        [HttpPut]
        public IActionResult Update()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return View();
        }
    }
}
