using System.Diagnostics.Contracts;

namespace FisherImageProject.Models
{
    public class ImageComment
    {
        public long Id { get; set; }
        public long ImageId { get; set; }
        public long UserId { get; set; }
        public string? Content { get; set; }
        public bool Hidden { get; set; } = false;
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
