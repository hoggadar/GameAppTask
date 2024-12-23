using GameAppTaskBusiness.DTOs.FriendRequest;
using GameAppTaskBusiness.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Security.Claims;

namespace GameAppTaskWeb.Controllers
{
    //[Authorize]
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

        [HttpGet]
        public IActionResult FriendList()
        {
            return View();
        }

        [HttpGet("Subscriptions/{userId}")]
        public async Task<IActionResult> SubscriptionsList(string userId)
        {
            var user = await _userService.GetById(userId);
            if (user == null) return BadRequest();
            var requests = await _friendRequestService.GetSubscriptionsBySenderId(user.Id);
            return Json(requests);
        }

        [HttpGet("Subscribers/{userId}")]
        public async Task<IActionResult> SubscribersList(string userId)
        {
            var user = await _userService.GetById(userId);
            if (user == null) return BadRequest();
            var requests = await _friendRequestService.GetSubscribersBySenderId(user.Id);
            return Json(requests);
        }

        //[HttpGet]
        //public async Task<IActionResult> RequestList()
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var requests = await _friendRequestService.GetRequestsBySenderId(userId!);
        //    return View(requests);
        //}

        [HttpPost]
        public async Task<IActionResult> SendFriendRequest([FromBody] CreateFriendRequestDto dto)
        {
            var createdFriendRequest = await _friendRequestService.SendFriendRequest(dto);
            return Json(createdFriendRequest);
        }

        [HttpGet]
        public async Task<IActionResult> AcceptFriendRequest(string id)
        {
            await _friendRequestService.AcceptFriendRequest(id);
            return Json(id);
        }
    }
}
