using AutoMapper;
using GameAppTaskBusiness.DTOs.BoardGame;
using GameAppTaskBusiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameAppTaskWeb.Controllers
{
    public class GameController : Controller
    {
        private readonly IBoardGameService _boardGameService;
        private readonly IMapper _mapper;
        private readonly ILogger<GameController> _logger;

        public GameController(IBoardGameService boardGameService, IMapper mapper, ILogger<GameController> logger)
        {
            _boardGameService = boardGameService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var boardGames = await _boardGameService.GetAll();
            return View(boardGames);
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

        [HttpPost]
        public IActionResult Update()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
    }
}
