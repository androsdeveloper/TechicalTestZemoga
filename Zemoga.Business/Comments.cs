using System.Collections.Generic;
using System.Linq;
using Zemoga.Business.Interfaces;
using Zemoga.DTO;

namespace Zemoga.Business
{
    public class Comments : IComment
    {
        public List<GeneralPostComments> GetCommentByIdPost(Post post)
        {
            List<Comment> lstCommentEntity = new List<Comment>();

            using (var db = new DAL.Models.TestContext())
            {
                var resultComment = db.Comments.Where(c => c.IdPost == post.IdPost).ToList();

                for (int j = 0; j < resultComment.Count; j++)
                {
                    lstCommentEntity.Add(new Comment
                    {
                        CreateDate = resultComment[j].CreateDate,
                        UserComment = resultComment[j].UserComment,
                        IdPost = resultComment[j].IdPost
                    });
                }
            }

            List<GeneralPostComments> lstGenPostComment = new List<GeneralPostComments>();
            lstGenPostComment.Add(new GeneralPostComments { CommentList = lstCommentEntity, Post = post });
            return lstGenPostComment;
        }

        public void Save(Comment comment)
        {
            using (var db = new DAL.Models.TestContext())
            {
                db.Comments.Add(new DAL.Models.Comment
                {
                    CreateDate = System.DateTime.Now,
                    IdPost = comment.IdPost,
                    UserComment = comment.UserComment
                });
                db.SaveChanges();
            }
        }
    }
}
