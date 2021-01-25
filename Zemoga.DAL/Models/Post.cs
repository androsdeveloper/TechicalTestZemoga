using System;
using System.Collections.Generic;

#nullable disable

namespace Zemoga.DAL.Models
{
    public partial class Post
    {
        public int IdPost { get; set; }
        public string Title { get; set; }
        public bool PendingApproval { get; set; }
        public bool Rejected { get; set; }
        public bool Published { get; set; }
        public string Content { get; set; }
        public int? IdWriter { get; set; }
        public DateTime? DatePublished { get; set; }
    }
}
