using AutoMapper;
using GameAppTaskBusiness.DTOs.FriendRequest;
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

        public async Task<IEnumerable<FriendRequestDto>> GetAllBySenderId(string id)
        {
            if (!Guid.TryParse(id, out Guid parsedId))
            {
                string message = $"Incorrect Guid format senderId: {id}";
                _logger.LogWarning(message);
                throw new FormatException(message);
            }
            var friendRequests = await _friendRequestRepo.GetAllBySenderId(parsedId);
            return _mapper.Map<IEnumerable<FriendRequestDto>>(friendRequests);
        }

        public async Task<IEnumerable<FriendRequestDto>> GetAllByRecipientId(string id)
        {
            if (!Guid.TryParse(id, out Guid parsedId))
            {
                string message = $"Incorrect Guid format recipientId: {id}";
                _logger.LogWarning(message);
                throw new FormatException(message);
            }
            var friendRequests = await _friendRequestRepo.GetAllByRecipientId(parsedId);
            return _mapper.Map<IEnumerable<FriendRequestDto>>(friendRequests);
        }

        public async Task<IEnumerable<FriendRequestFullDto>> GetSubscriptionsBySenderId(string senderId)
        {
            if (!Guid.TryParse(senderId, out Guid parsedSenderId))
            {
                string message = $"Incorrect Guid format recipientId: {senderId}";
                _logger.LogWarning(message);
                throw new FormatException(message);
            }
            var subscriptions = await _friendRequestRepo.GetSubscriptionsBySenderId(parsedSenderId);
            return _mapper.Map<IEnumerable<FriendRequestFullDto>>(subscriptions);
        }

        public async Task<IEnumerable<FriendRequestDto>> GetSubscribersBySenderId(string senderId)
        {
            if (!Guid.TryParse(senderId, out Guid parsedSenderId))
            {
                string message = $"Incorrect Guid format recipientId: {senderId}";
                _logger.LogWarning(message);
                throw new FormatException(message);
            }
            var subscribers = await _friendRequestRepo.GetSubscribersBySenderId(parsedSenderId);
            return _mapper.Map<IEnumerable<FriendRequestDto>>(subscribers);
        }

        public async Task<IEnumerable<FriendRequestDto>> GetFriendsBySenderId(string senderId)
        {
            if (!Guid.TryParse(senderId, out Guid parsedSenderId))
            {
                string message = $"Incorrect Guid format recipientId: {senderId}";
                _logger.LogWarning(message);
                throw new FormatException(message);
            }
            var friends = await _friendRequestRepo.GetFriendsBySenderId(parsedSenderId);
            return _mapper.Map<IEnumerable<FriendRequestDto>>(friends);
        }

        public async Task<FriendRequestDto?> GetBySenderIdAndRecipientId(string senderId, string recipientId)
        {
            if (!Guid.TryParse(senderId, out Guid parsedSenderId) || !Guid.TryParse(recipientId, out Guid parsedRecipientId))
            {
                string message = $"Incorrect Guid format senderId: {senderId} or recipientId: {recipientId}";
                _logger.LogWarning(message);
                throw new FormatException(message);
            }
            var friendRequest = await _friendRequestRepo.GetBySenderIdAndRecipientId(parsedSenderId, parsedRecipientId);
            return _mapper.Map<FriendRequestDto>(friendRequest);
        }

        public async Task<FriendRequestDto> SendFriendRequest(CreateFriendRequestDto dto)
        {
            if (!Guid.TryParse(dto.SenderId, out Guid parsedSenderId) || !Guid.TryParse(dto.RecipientId, out Guid parsedRecipientId))
            {
                string message = $"Incorrect Guid format senderId: {dto.SenderId} or recipientId: {dto.RecipientId}";
                _logger.LogWarning(message);
                throw new FormatException(message);
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
