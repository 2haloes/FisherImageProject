namespace FisherImageProject.Models
{
    public class ImageCommentVote
    {
        public long Id { get; set; }
        public long ImageCommentId { get; set; }
        public long UserId { get; set; }
        public bool PositiveVote { get; set; } = false;
        public DateTime? CreationDate { get; set; }
    }
}
