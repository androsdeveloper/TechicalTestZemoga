using System;
using System.Collections.Generic;

#nullable disable

namespace Zemoga.DAL.Models
{
    public partial class Comment
    {
        public int IdComment { get; set; }

        public int IdPost { get; set; }
        public string UserComment { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
