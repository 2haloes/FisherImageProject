namespace FisherImageProject.Models
{
    public class ImageTag
    {
        public long Id { get; set; }
        public long TagId { get; set; }
        public long PositiveVotes { get; set; }
        public long NegitiveVotes { get; set; }
    }
}
