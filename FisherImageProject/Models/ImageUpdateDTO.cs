using System.ComponentModel.DataAnnotations.Schema;

namespace FisherImageProject.Models
{
    public class ImageUpdateDTO
    {
        public long? Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageSource { get; set; }
        public bool? Hidden { get; set; }
    }
}
