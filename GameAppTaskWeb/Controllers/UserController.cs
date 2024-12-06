using AutoMapper;
using GameAppTaskBusiness.DTOs.User;
using GameAppTaskBusiness.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameAppTaskWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBoardGameService _boardGameService;
        private readonly IFavouriteService _favouriteService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, IBoardGameService boardGameService, IFavouriteService favouriteService, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService;
            _boardGameService = boardGameService;
            _favouriteService = favouriteService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var users = await _userService.GetAll();
                return View(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> FavouriteBoardGames(string id)
        {
            var user = await _userService.GetById(id);
            var favourites = await _boardGameService.GetAllByUserId(id);
            var dto = new UserWithBoardGamesDto
            {
                User = user,
                BoardGames = favourites
            };
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFromFavourite(string userId, string boardGameId)
        {
            var user = await _userService.GetById(userId);
            var favourite = await _favouriteService.GetByUserIdAndBoardGameId(user.Id, boardGameId);
            if (favourite != null)
            {
                var deletedFavourite = await _favouriteService.Delete(favourite.Id);
            }
            return RedirectToAction("FavouriteBoardGames", new { id = user.Id });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdUser = await _userService.Create(dto);
                    return RedirectToAction("Index");
                }
                return View(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            try
            {
                var selectedUser = await _userService.GetById(id);
                var dto = _mapper.Map<UpdateUserDto>(selectedUser);
                return View(dto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, UpdateUserDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updatedUser = await _userService.Update(id, dto);
                    RedirectToAction("Index");
                }
                return View(dto);
            } catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _userService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Message: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
