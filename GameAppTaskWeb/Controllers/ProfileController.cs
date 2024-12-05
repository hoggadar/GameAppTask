using GameAppTaskBusiness.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameAppTaskWeb.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBoardGameService _boardGameService;
        private readonly IFavouriteService _favouriteService;

        public ProfileController(IUserService userService, IBoardGameService boardGameService, IFavouriteService favouriteService)
        {
            _userService = userService;
            _boardGameService = boardGameService;
            _favouriteService = favouriteService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = await _userService.GetById(userId!);
            return View(currentUser);
        }

        [HttpGet]
        public async Task<IActionResult> FavouriteBoardGames()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var favourites = await _boardGameService.GetAllByUserId(userId!);
            return View(favourites);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> DeleteFromFavourite(string id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var favourite = await _favouriteService.GetByUserIdAndBoardGameId(userId!, id);
            if (favourite != null)
            {
                var deletedFavourite = await _favouriteService.Delete(favourite.Id);
            }
            return RedirectToAction("FavouriteBoardGames");
        }
    }
}
