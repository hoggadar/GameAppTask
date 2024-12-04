using AutoMapper;
using GameAppTaskBusiness.DTOs.BoardGame;
using GameAppTaskBusiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameAppTaskWeb.Controllers
{
    public class BoardGameController : Controller
    {
        private readonly IBoardGameService _boardGameService;
        private readonly IMapper _mapper;
        private readonly ILogger<BoardGameController> _logger;

        public BoardGameController(IBoardGameService boardGameService, IMapper mapper, ILogger<BoardGameController> logger)
        {
            _boardGameService = boardGameService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string title = "", int pageIndex = 1, int pageSize = 10)
        {
            var boardGames = await _boardGameService.GetAllByTitle(title, pageIndex, pageSize);
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
