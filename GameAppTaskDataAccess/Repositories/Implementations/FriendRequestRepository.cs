using GameAppTaskDataAccess.Data;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameAppTaskDataAccess.Repositories.Implementations
{
    public class FriendRequestRepository : Repository<FriendRequestModel>, IFriendRequestRepository
    {
        public FriendRequestRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<FriendRequestModel>> GetAllBySenderId(Guid senderId)
        {
            var friendRequests = await _context.Friends
                .Where(p => p.SenderId == senderId)
                .ToListAsync();
            return friendRequests;
        }

        public async Task<IEnumerable<FriendRequestModel>> GetAllByRecipientId(Guid recipientId)
        {
            var friendRequests = await _context.Friends
                .Where(p => p.RecipientId == recipientId)
                .ToListAsync();
            return friendRequests;
        }

        public async Task<IEnumerable<FriendRequestModel>> GetSubscriptionsBySenderId(Guid senderId)
        {
            var subscriptions = await _context.Friends
                .Where(p => p.SenderId == senderId && p.IsAccepted == false)
                .Include(p => p.Recipient)
                .Include(p => p.Sender)
                .ToListAsync();
            return subscriptions;
        }

        public async Task<IEnumerable<FriendRequestModel>> GetSubscribersBySenderId(Guid senderId)
        {
            var subscribers = await _context.Friends
                .Where(p => p.RecipientId == senderId && p.IsAccepted == false)
                .ToListAsync();
            return subscribers;
        }

        public async Task<IEnumerable<FriendRequestModel>> GetFriendsBySenderId(Guid senderId)
        {
            var friends = await _context.Friends
                .Where(p => p.SenderId == senderId && p.IsAccepted == true)
                .ToListAsync();
            return friends;
        }

        public async Task<FriendRequestModel?> GetBySenderIdAndRecipientId(Guid senderId, Guid recipientId)
        {
            var friendRequests = await _context.Friends
                .Where(p => p.SenderId == senderId && p.RecipientId == recipientId)
                .FirstOrDefaultAsync();
            return friendRequests;
        }
    }
}
