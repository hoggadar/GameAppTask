using GameAppTaskDataAccess.Data;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameAppTaskDataAccess.Repositories.Implementations
{
    public class FriendRequestRepository : Repository<FriendRequestModel>, IFriendRequestRepository
    {
        public FriendRequestRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<FriendRequestModel>> GetAllBySenderId(Guid id)
        {
            var friendRequests = await _context.Friends.Where(p => p.SenderId == id).ToListAsync();
            return friendRequests;
        }

        public async Task<IEnumerable<FriendRequestModel>> GetAllByRecipientId(Guid id)
        {
            var friendRequests = await _context.Friends.Where(p => p.RecipientId == id).ToListAsync();
            return friendRequests;
        }

        public async Task<IEnumerable<FriendRequestModel>> GetFriendsBySenderId(Guid id)
        {
            var friends = await _context.Friends.Where(p => p.SenderId == id && p.IsAccepted == true).ToListAsync();
            return friends;
        }

        public async Task<IEnumerable<FriendRequestModel>> GetRequestsBySenderId(Guid id)
        {
            var requests = await _context.Friends.Where(p => p.SenderId == id && p.IsAccepted == false).ToListAsync();
            return requests;
        }

        public async Task<FriendRequestModel?> GetBySenderIdAndRecipientId(Guid senderId, Guid recipientId)
        {
            var request = await _context.Friends.Where(p => p.SenderId == senderId && p.RecipientId == recipientId).FirstOrDefaultAsync();
            return request;
        }
    }
}
