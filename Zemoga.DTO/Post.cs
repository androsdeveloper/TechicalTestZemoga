using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zemoga.DTO
{
    public class Post
    {
        public int IdPost { get; set; }

        [Required(ErrorMessage = "Title field is mandatory")]
        public string Title { get; set; }
        public bool PendingApproval { get; set; }
        public bool Rejected { get; set; }
        public bool Published { get; set; }
        [Required(ErrorMessage = "Content field is mandatory")]
        public string Content { get; set; }
        public int? IdWriter { get; set; }
        public DateTime? DatePublished { get; set; }

        public string? nameWriter { get; set; }
    }
}
