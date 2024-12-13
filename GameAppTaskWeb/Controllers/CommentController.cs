using GameAppTaskBusiness.DTOs.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameAppTaskWeb.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentDto dto)
        {
            return Ok(dto);
        }
    }
}
