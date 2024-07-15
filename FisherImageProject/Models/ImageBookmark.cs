namespace FisherImageProject.Models
{
    public class ImageBookmark
    {
        public long Id { get; set; }
        public long ImageId { get; set; }
        public long UserId { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
