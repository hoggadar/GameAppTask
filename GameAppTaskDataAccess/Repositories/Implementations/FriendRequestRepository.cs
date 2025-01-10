using GameAppTaskDataAccess.Data;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace GameAppTaskDataAccess.Repositories.Implementations
{
    public class FriendRequestRepository : Repository<FriendRequestModel>, IFriendRequestRepository
    {
        public FriendRequestRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<UserModel>> GetSubscriptionsByUserId(Guid userId)
        {
            var subscriptions = await _context.Friends
                .Where(fr => fr.SenderId == userId && !fr.IsAccepted)
                .Include(fr => fr.Recipient)
                .Select(fr => fr.Recipient)
                .Distinct()
                .ToListAsync();
            return subscriptions;
        }

        public async Task<IEnumerable<UserModel>> GetSubscribersByUserId(Guid userId)
        {
            var subscribers = await _context.Friends
                .Where(fr => fr.RecipientId == userId && !fr.IsAccepted)
                .Include(fr => fr.Sender)
                .Select(fr => fr.Sender)
                .ToListAsync();
            return subscribers;
        }

        public async Task<IEnumerable<UserModel>> GetFriendsByUserId(Guid userId)
        {
            var friendRequests = await _context.Friends
                .Where(fr => (fr.SenderId == userId || fr.RecipientId == userId) && fr.IsAccepted)
                .Include(fr => fr.Sender)
                .Include(fr => fr.Recipient)
                .ToListAsync();

            var friends = friendRequests
                .SelectMany(fr => new[] { fr.Sender, fr.Recipient })
                .Where(u => u.Id != userId)
                .DistinctBy(u => u.Id)
                .ToList();

            return friends;
        }

        public async Task<FriendRequestModel?> GetBySenderIdAndRecipientId(Guid senderId, Guid recipientId)
        {
            var friendRequests = await _context.Friends
                .Where(p => p.SenderId == senderId && p.RecipientId == recipientId)
                .Where(p => p.SenderId == recipientId && p.RecipientId == senderId)
                .FirstOrDefaultAsync();
            return friendRequests;
        }
    }
}
