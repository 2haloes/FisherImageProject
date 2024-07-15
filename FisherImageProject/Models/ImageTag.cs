namespace FisherImageProject.Models
{
    public class ImageTag
    {
        public long Id { get; set; }
        public long TagId { get; set; }
        public long UserId { get; set; }
        public bool PositiveVote { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
