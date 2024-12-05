using AutoMapper;
using GameAppTaskBusiness.DTOs.BoardGame;
using GameAppTaskBusiness.DTOs.Favourite;
using GameAppTaskBusiness.Interfaces;
using GameAppTaskDataAccess.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameAppTaskWeb.Controllers
{
    public class BoardGameController : Controller
    {
        private readonly IBoardGameService _boardGameService;
        private readonly IFavouriteService _favouriteService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<BoardGameController> _logger;

        public BoardGameController(IBoardGameService boardGameService, IFavouriteService favouriteService, IMapper mapper, IWebHostEnvironment environment, ILogger<BoardGameController> logger)
        {
            _boardGameService = boardGameService;
            _favouriteService = favouriteService;
            _mapper = mapper;
            _environment = environment;
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index(GenreEnum? genre)
        {
            var boardGames = await _boardGameService.GetAllByGenre(genre);
            return View(boardGames);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateBoardGameDto dto)
        {
            if (ModelState.IsValid)
            {
                dto.ImagePath = string.Empty;
                var createdBoardGame = await _boardGameService.Create(dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(CreateBoardGameDto dto, IFormFile ImageFile)
        //{
        //    try
        //    {
        //        if (ImageFile != null)
        //        {
        //            string folder = Path.Combine(_environment.WebRootPath, "images");
        //            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

        //            string temp = Path.GetFileName(ImageFile.FileName);
        //            string timeStamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
        //            string imageName = $"{Path.GetFileNameWithoutExtension(temp)}_{timeStamp}{Path.GetExtension(temp)}";
        //            string imagePath = Path.Combine(folder, imageName);
        //            using (var stream = new FileStream(imagePath, FileMode.Create))
        //            {
        //                await ImageFile.CopyToAsync(stream);
        //            }
        //            dto.ImagePath = imageName;

        //            var createdBoardGame = await _boardGameService.Create(dto);
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex.Message);
        //    }

        //    return View(dto);
        //}

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var selectedBoardGame = await _boardGameService.GetById(id);
            var dto = _mapper.Map<UpdateBoardGameDto>(selectedBoardGame);
            return View(dto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Update(string id, UpdateBoardGameDto dto)
        {
            if (ModelState.IsValid)
            {
                var updatedBoardGame = await _boardGameService.Update(id, dto);
                return RedirectToAction("Index");
            }
            return View(dto);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var deletedBoardGame = await _boardGameService.Delete(id); 
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddToFavourites(string boardGameId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var favourite = await _favouriteService.GetByUserIdAndBoardGameId(userId!, boardGameId);
            if (favourite == null)
            {
                var dto = new CreateFavouriteDto
                {
                    UserId = userId!,
                    BoardGameId = boardGameId,
                };
                var createdFavourite = await _favouriteService.Create(dto);
            }
            return RedirectToAction("Index");
        }
    }
}
