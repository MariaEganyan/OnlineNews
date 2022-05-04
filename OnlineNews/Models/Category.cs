using System;
using System.Collections.Generic;

namespace OnlineNews.Models
{
    public partial class Category
    {
        public Category()
        {
            News = new HashSet<New>();
        }

        public int Categoryid { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<New> News { get; set; }
    }
}
