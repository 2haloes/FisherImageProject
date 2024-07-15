namespace FisherImageProject.Models
{
    public class User
    {
        public long Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        // Replace this with something much better after understanding improves
        public string? Password { get; set; }
        public Image? AvatarImage { get; set; }
        public long? AvatarImageId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public List<Image>? Images { get; } = new List<Image>();
    }
}
