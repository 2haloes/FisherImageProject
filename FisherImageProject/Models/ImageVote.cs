namespace FisherImageProject.Models
{
    public class ImageVote
    {
        public long Id { get; set; }
        public long ImageId { get; set; }
        public long UserId { get; set; }
        public bool PositiveVote { get; set; }
    }
}
