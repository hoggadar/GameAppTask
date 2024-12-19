using GameAppTaskBusiness.DTOs.FriendRequest;
using GameAppTaskBusiness.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameAppTaskWeb.Controllers
{
    public class FriendRequestController : Controller
    {
        private readonly IUserService _userService;
        private readonly IFriendRequestService _friendRequestService;
        private readonly ILogger<FriendRequestController> _logger;

        public FriendRequestController(IUserService userService, IFriendRequestService friendRequestService, ILogger<FriendRequestController> logger)
        {
            _userService = userService;
            _friendRequestService = friendRequestService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendFriendRequest([FromBody] CreateFriendRequestDto dto)
        {
            var createdFriendRequest = await _friendRequestService.SendFriendRequest(dto);
            return Json(createdFriendRequest);
        }

        [HttpGet]
        public async Task<IActionResult> AcceptFriendRequest()
        {
            return Ok();
        }
    }
}
