namespace GameAppTaskBusiness.DTOs.Comment
{
    public class CommentWithUserDto
    {
        public string Id { get; set; } = null!;
        public string Text { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string UserFirstName { get; set; } = null!;
        public string UserLastName { get; set; } = null!;
        public string? ParentCommentId { get; set; }
    }
}
