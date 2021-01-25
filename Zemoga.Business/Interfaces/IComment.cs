using System.Collections.Generic;
using Zemoga.DTO;

namespace Zemoga.Business.Interfaces
{
    public interface IComment
    {
        void Save(Comment comment);
        List<GeneralPostComments> GetCommentByIdPost(Post post);
    }
}
