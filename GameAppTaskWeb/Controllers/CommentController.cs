using GameAppTaskBusiness.DTOs.Comment;
using GameAppTaskBusiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameAppTaskWeb.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly ILogger<CommentController> _logger;

        public CommentController(ICommentService commentService, ILogger<CommentController> logger)
        {
            _commentService = commentService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] CreateCommentDto dto)
        {
            _logger.LogInformation($"from dto: {dto.Text} {dto.UserId} {dto.BoardGameId} {dto.ParentCommentId}");
            var createdComment = await _commentService.Create(dto);
            return Json(createdComment);
        }
    }
}
