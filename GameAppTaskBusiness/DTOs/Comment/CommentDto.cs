namespace GameAppTaskBusiness.DTOs.Comment
{
    public class CommentDto : CommentBase
    {
        public string Id { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
