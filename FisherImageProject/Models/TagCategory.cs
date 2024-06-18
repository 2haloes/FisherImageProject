namespace FisherImageProject.Models
{
    public class TagCategory
    {
        public long Id { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public int CategoryRank { get; set; }
        public string? CategoryColor { get; set; }
    }
}
