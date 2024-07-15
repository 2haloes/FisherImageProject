using System.ComponentModel.DataAnnotations.Schema;

namespace FisherImageProject.Models
{
    public class Image
    {
        public long? Id { get; set; }
        public long? UserId { get; set; }
        public User? User { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageSource { get; set; }
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageData { get; set; }
        public bool? Hidden { get; set; }
        public DateTime? CreationTime { get; set; }
        public DateTime? ModifiedTime { get; set;}
    }
}
