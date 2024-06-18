namespace FisherImageProject.Models
{
    public class Image
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string ImageSource { get; set; }
        public string? ImageUrl { get; set; }
        public bool Hidden { get; set; } = false;
    }
}
