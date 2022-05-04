namespace OnlineNews.Models
{
    public class NewDto
    {
        public int Newsid { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? Categoryid { get; set; }
        public DateTime? Datetime { get; set; }

    }
}
