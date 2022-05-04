using System;
using System.Collections.Generic;

namespace OnlineNews.Models
{
    public partial class New
    {
        public int Newsid { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? Categoryid { get; set; }
        public DateTime? Datetime { get; set; }= DateTime.Now;

        public virtual Category? Category { get; set; }
    }
}
