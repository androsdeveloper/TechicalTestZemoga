using System;
using System.Collections.Generic;
using System.Text;

namespace Zemoga.DTO
{
    public class Comment
    {
        public int IdComment { get; set; }
        public int IdPost { get; set; }
        public string UserComment { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
