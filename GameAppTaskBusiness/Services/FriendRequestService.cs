using AutoMapper;
using GameAppTaskBusiness.DTOs.FriendRequest;
using GameAppTaskBusiness.DTOs.User;
using GameAppTaskBusiness.Interfaces;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace GameAppTaskBusiness.Services
{
    public class FriendRequestService : IFriendRequestService
    {
        private readonly IFriendRequestRepository _friendRequestRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<FriendRequestService> _logger;

        public FriendRequestService(IFriendRequestRepository  friendRequestRepo, IMapper mapper, ILogger<FriendRequestService> logger)
        {
            _friendRequestRepo = friendRequestRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<UserDto>> GetSubscriptionsByUserId(string userId)
        {
            if (!Guid.TryParse(userId, out Guid parsedUserId))
            {
                string message = $"Incorrect Guid format recipientId: {userId}";
                _logger.LogWarning(message);
                throw new FormatException(message);
            }
            var subscriptions = await _friendRequestRepo.GetSubscriptionsByUserId(parsedUserId);
            return _mapper.Map<IEnumerable<UserDto>>(subscriptions);
        }

        public async Task<IEnumerable<UserDto>> GetSubscribersByUserId(string userId)
        {
            if (!Guid.TryParse(userId, out Guid parsedUserId))
            {
                string message = $"Incorrect Guid format recipientId: {userId}";
                _logger.LogWarning(message);
                throw new FormatException(message);
            }
            var subscribers = await _friendRequestRepo.GetSubscribersByUserId(parsedUserId);
            return _mapper.Map<IEnumerable<UserDto>>(subscribers);
        }

        public async Task<IEnumerable<UserDto>> GetFriendsByUserId(string userId)
        {
            if (!Guid.TryParse(userId, out Guid parsedUserId))
            {
                string message = $"Incorrect Guid format recipientId: {userId}";
                _logger.LogWarning(message);
                throw new FormatException(message);
            }
            var friends = await _friendRequestRepo.GetFriendsByUserId(parsedUserId);
            return _mapper.Map<IEnumerable<UserDto>>(friends);
        }

        public async Task<FriendRequestDto> SendFriendRequest(CreateFriendRequestDto dto)
        {
            string message;
            if (dto.SenderId == dto.RecipientId)
            {
                throw new ArgumentException("The sender's ID cannot be equal to the recipient's ID");
            }
            if (!Guid.TryParse(dto.SenderId, out Guid parsedSenderId) || !Guid.TryParse(dto.RecipientId, out Guid parsedRecipientId))
            {
                message = $"Incorrect Guid format senderId: {dto.SenderId} or recipientId: {dto.RecipientId}";
                _logger.LogWarning(message);
                throw new FormatException(message);
            }
            var request = await _friendRequestRepo.GetBySenderIdAndRecipientId(parsedRecipientId, parsedSenderId);
            if (request != null)
            {
                message = "Request already exists";
                _logger.LogWarning(message);
                throw new InvalidDataException(message);
            }
            var newFriendRequest = _mapper.Map<FriendRequestModel>(dto);
            newFriendRequest.Id = Guid.NewGuid();
            newFriendRequest.IsAccepted = false;
            newFriendRequest.CreatedAt = DateTime.UtcNow;
            var createdFriendRequest = await _friendRequestRepo.Create(newFriendRequest);
            return _mapper.Map<FriendRequestDto>(createdFriendRequest);
        }

        public async Task<FriendRequestDto> AcceptFriendRequest(string id)
        {
            string message;
            if (!Guid.TryParse(id, out Guid parsedId))
            {
                message = $"Incorrect Guid format senderId: {id}";
                _logger.LogWarning(message);
                throw new FormatException(message);
            }
            var friendRequest = await _friendRequestRepo.GetById(parsedId);
            if (friendRequest == null)
            {
                message = $"FriendRequest with ID = {id} not found.";
                _logger.LogWarning(message);
                throw new KeyNotFoundException(message);
            }
            friendRequest.IsAccepted = true;
            var updatedFriendRequest = await _friendRequestRepo.Update(friendRequest);
            return _mapper.Map<FriendRequestDto>(updatedFriendRequest);
        }
    }
}
