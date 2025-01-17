﻿namespace GameAppTaskBusiness.DTOs.Comment
{
    public class CommentBase
    {
        public string Text { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string BoardGameId { get; set; } = null!;
        public string UserFirstName { get; set; } = null!;
        public string UserLastName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string? ParentCommentId { get; set; }
    }
}
