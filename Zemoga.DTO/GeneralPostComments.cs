using System;
using System.Collections.Generic;
using System.Text;

namespace Zemoga.DTO
{
    public class GeneralPostComments
    {
        public Post Post { get; set; }
        public List<Comment> CommentList { get; set; }
    }
}
