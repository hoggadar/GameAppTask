using AutoMapper;
using GameAppTaskBusiness.DTOs.Comment;
using GameAppTaskBusiness.Interfaces;
using GameAppTaskDataAccess.Models;
using GameAppTaskDataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace GameAppTaskBusiness.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<CommentService> _logger;

        public CommentService(ICommentRepository commentRepo, IUserService userService, IMapper mapper, ILogger<CommentService> logger)
        {
            _commentRepo = commentRepo;
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<CommentDto>> GetAllByGameId(string gameId)
        {
            if (!Guid.TryParse(gameId, out Guid parsedGameId))
            {
                string message = $"Incorrect Guid format gameId: {gameId}";
                _logger.LogWarning(message);
                throw new FormatException(message);
            }
            var comments = await _commentRepo.GetAllByGameId(parsedGameId);
            return _mapper.Map<IEnumerable<CommentDto>>(comments);
        }

        public async Task<CommentDto> Create(CreateCommentDto dto)
        {
            try
            {
                var newComment = _mapper.Map<CommentModel>(dto);
                if (!Guid.TryParse(dto.UserId, out Guid parsedUserId) || !Guid.TryParse(dto.BoardGameId, out Guid parsedBoardGameId))
                {
                    string message = $"Incorrect Guid format userId: {dto.UserId} or boardGameId: {dto.BoardGameId}";
                    _logger.LogWarning(message);
                    throw new FormatException(message);
                }
                var lastComment = await _commentRepo.GetLastByGameId(newComment.BoardGameId);
                newComment.Id = Guid.NewGuid();
                newComment.CreatedAt = DateTime.UtcNow;
                if (lastComment != null) newComment.ParentCommentId = lastComment.Id;
                var createdComment = await _commentRepo.Create(newComment);
                return _mapper.Map<CommentDto>(createdComment);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error mapping CreateCommentDto to CommentModel");
                throw new ArgumentException("Invalid data provided for comment creation", ex);
            }
        }
    }
}
