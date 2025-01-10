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
        public async Task<IActionResult> GetSubscriptionsList(string userId)
        {
            var user = await _userService.GetById(userId);
            if (user == null) return BadRequest();
            var requests = await _friendRequestService.GetSubscriptionsByUserId(user.Id);
            return Json(requests);
        }

        [HttpGet("Subscribers/{userId}")]
        public async Task<IActionResult> GetSubscribersList(string userId)
        {
            var user = await _userService.GetById(userId);
            if (user == null) return BadRequest();
            var requests = await _friendRequestService.GetSubscribersByUserId(user.Id);
            return Json(requests);
        }

        [HttpGet("Friends/{userId}")]
        public async Task<IActionResult> GetFriendsList(string userId)
        {
            var user = await _userService.GetById(userId);
            if (user == null) return BadRequest();
            var requests = await _friendRequestService.GetFriendsByUserId(user.Id);
            return Json(requests);
        }

        [HttpPost]
        public async Task<IActionResult> SendFriendRequest([FromBody] CreateFriendRequestDto dto)
        {
            try
            {
                var createdFriendRequest = await _friendRequestService.SendFriendRequest(dto);
                return Json(createdFriendRequest);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AcceptFriendRequest(string id)
        {
            var acceptedFriendRequest = await _friendRequestService.AcceptFriendRequest(id);
            return Json(acceptedFriendRequest);
        }
    }
}
