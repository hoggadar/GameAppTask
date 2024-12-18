using AutoMapper;
using GameAppTaskBusiness.DTOs.BoardGame;
using GameAppTaskBusiness.DTOs.Favourite;
using GameAppTaskBusiness.Interfaces;
using GameAppTaskDataAccess.Enums;
using GameAppTaskWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GameAppTaskWeb.Controllers
{
    public class BoardGameController : Controller
    {
        private readonly IBoardGameService _boardGameService;
        private readonly IFavouriteService _favouriteService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<BoardGameController> _logger;

        public BoardGameController(IBoardGameService boardGameService, IFavouriteService favouriteService, ICommentService commentService, IMapper mapper, IWebHostEnvironment environment, ILogger<BoardGameController> logger)
        {
            _boardGameService = boardGameService;
            _favouriteService = favouriteService;
            _commentService = commentService;
            _mapper = mapper;
            _environment = environment;
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index(string searchString, GenreEnum? selectedGenre, int pageNumber = 1, int pageSize = 2)
        {
            ViewData["CurrentSearch"] = searchString;
            ViewData["SelectedFilter"] = selectedGenre.ToString();
            var boardGames = await _boardGameService.GetAllByTitleAndGenre(searchString, selectedGenre, pageNumber, pageSize);
            return View(boardGames);
        }

        [HttpGet]
        public async Task<IActionResult> BoardGamePage(string boardGameId)
        {
            var model = await _boardGameService.GetByIdWithComments(boardGameId);
            return View(model);
        }

        // TEST ENDPOINT
        [HttpGet]
        public async Task<ActionResult<BoardGameWithCommentsDto>> GetByIdWithComments()
        {
            try
            {
                string temp = "88190E80-933F-44D4-A20E-E0C1B68D9A63";
                var boardGame = await _boardGameService.GetByIdWithComments(temp);
                return Ok(boardGame);
            }
            catch (FormatException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting board game with comments");
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateBoardGameDto dto, IFormFile image)
        {
            try
            {
                if (image != null && image.Length > 0)
                {
                    var path = Path.Combine(_environment.WebRootPath, "images");
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    var filePath = Path.Combine(path, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                    dto.ImagePath = fileName;
                }

                var createdBoardGame = await _boardGameService.Create(dto);

                return View(dto);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return View(dto);
            }
            
        }

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
