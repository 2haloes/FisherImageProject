namespace FisherImageProject.Models
{
    public class Tag
    {
        public long Id { get; set; }
        public string TagName { get; set; }
        public long TagCategoryId { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
