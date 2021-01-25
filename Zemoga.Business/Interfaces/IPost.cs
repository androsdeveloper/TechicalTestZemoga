using System.Collections.Generic;
using Zemoga.DTO;

namespace Zemoga.Business.Interfaces
{
    public interface IPost
    {
        List<Post> GetByPendingApproval();
        List<Post> GetAllPost();
        List<Post> GetByRejected();
        void Save(Post post);
        List<Post> GetDetailsById(int id);
        void Edit(Post post, string operationSubmit = null);
        void Delete(int id);
    }
}
