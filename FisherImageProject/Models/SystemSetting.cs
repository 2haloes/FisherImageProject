namespace FisherImageProject.Models
{
    public class SystemSetting
    {
        public long Id { get; set; }
        public long VotesPromoteTag { get; set; }
        public long VotesDemoteTag { get; set; }
        public long VotesHideComment {  get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}
