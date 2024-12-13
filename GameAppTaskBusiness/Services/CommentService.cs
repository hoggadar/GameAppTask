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
        private readonly IMapper _mapper;
        private readonly ILogger<CommentService> _logger;

        public CommentService(ICommentRepository commentRepo, IMapper mapper, ILogger<CommentService> logger)
        {
            _commentRepo = commentRepo;
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
            var newComment = _mapper.Map<CommentModel>(dto);
            newComment.Id = Guid.NewGuid();
            var createdComment = await _commentRepo.Create(newComment);
            return _mapper.Map<CommentDto>(createdComment);
        }
    }
}
