
using System.Collections.Generic;
using System.Linq;
using Zemoga.Business.Interfaces;
using Zemoga.DTO;

namespace Zemoga.Business
{
    public class Posts : IPost
    {
        //private readonly IConfiguration _config;
        public Posts()
        {
            //_config = config;
        }
        public List<Post> GetByPendingApproval()
        {
            List<Post> lstPostEntity = new List<Post>();
            using (var db = new DAL.Models.TestContext())
            {
                var result = from p in db.Posts
                             join u in db.Users on p.IdWriter equals u.IdUser
                              into a
                             from b in a.DefaultIfEmpty()
                             where p.PendingApproval == true
                             select new
                             {
                                 Title = p.Title,
                                 Content = p.Content,
                                 IdPost = p.IdPost,
                                 IdWriter = p.IdWriter,
                                 nameWriter = b.NameUser,
                                 Rejected = p.Rejected,
                             };

                foreach (var item in result)
                {
                    lstPostEntity.Add(new Post
                    {
                        Title = item.Title,
                        Content = item.Content,
                        IdPost = item.IdPost,
                        IdWriter = item.IdWriter,
                        nameWriter = item.nameWriter,
                        Rejected = item.Rejected
                    });
                }
            }
            return lstPostEntity;
        }

        public List<Post> GetAllPost()
        {
            List<Post> lstPostEntity = new List<Post>();
            List<Comment> lstCommentEntity = new List<Comment>();

            using (var db = new DAL.Models.TestContext())
            {                
                var result = (from p in db.Posts
                             join u in db.Users on p.IdWriter equals u.IdUser
                              into a
                             from b in a.DefaultIfEmpty()
                             where p.Published == true
                             select new
                             {
                                 Title = p.Title,
                                 Content = p.Content,
                                 IdPost = p.IdPost,
                                 IdWriter = p.IdWriter,
                                 nameWriter = b.NameUser,
                                 Rejected = p.Rejected,
                                 DatePublished = p.DatePublished
                             }).OrderByDescending(o => o.DatePublished);

                foreach (var item in result)
                {
                    lstPostEntity.Add(new Post
                    {
                        Title = item.Title,
                        Content = item.Content,
                        IdPost = item.IdPost,
                        IdWriter = item.IdWriter,
                        nameWriter = item.nameWriter,
                        Rejected = item.Rejected,
                        DatePublished = item.DatePublished
                    });
                }

            }
            return lstPostEntity;
        }

        public List<Post> GetByRejected()
        {
            List<Post> lstPostEntity = new List<Post>();
            using (var db = new DAL.Models.TestContext())
            {

                var result = from p in db.Posts
                             join u in db.Users on p.IdWriter equals u.IdUser
                              into a
                             from b in a.DefaultIfEmpty()
                             where p.Rejected == true
                             select new
                             {
                                 Title = p.Title,
                                 Content = p.Content,
                                 IdPost = p.IdPost,
                                 IdWriter = p.IdWriter,
                                 nameWriter = b.NameUser,
                                 Rejected = p.Rejected,
                             };

                foreach (var item in result)
                {
                    lstPostEntity.Add(new Post
                    {
                        Title = item.Title,
                        Content = item.Content,
                        IdPost = item.IdPost,
                        IdWriter = item.IdWriter,
                        nameWriter = item.nameWriter,
                        Rejected = item.Rejected
                    });
                }
            }
            return lstPostEntity;
        }

        public void Save(Post post)
        {
            using (var db = new DAL.Models.TestContext())
            {
                db.Posts.Add(new DAL.Models.Post
                {
                    Content = post.Content,
                    IdWriter = 1,
                    Rejected = post.Rejected,
                    Published = post.Published,
                    PendingApproval = true,
                    Title = post.Title
                });
                db.SaveChanges();
            }
        }

        public List<Post> GetDetailsById(int id)
        {
            List<Post> lstPostEntity = new List<Post>();
            using (var db = new DAL.Models.TestContext())
            {
                var result = db.Posts.Where(c => c.IdPost == id).ToList();


                for (int i = 0; i < result.Count; i++)
                {
                    lstPostEntity.Add(new Post
                    {
                        Content = result[i].Content,
                        IdPost = result[i].IdPost,
                        IdWriter = result[i].IdPost,
                        Rejected = result[i].Rejected,
                        Published = result[i].Published,
                        Title = result[i].Title,
                        DatePublished = result[i].DatePublished
                    });
                }
            };

            return lstPostEntity;
        }

        public void Edit(Post post, string operationSubmit = null)
        {
            using (var db = new DAL.Models.TestContext())
            {
                var findPost = db.Posts.Find(post.IdPost);
                findPost.Title = string.IsNullOrEmpty(post.Title) ? post.Title : findPost.Title;
                findPost.Content = string.IsNullOrEmpty(post.Content) ? post.Content : findPost.Content;
                findPost.PendingApproval = operationSubmit == "Reject" || operationSubmit == "Publish" ? false : true;
                findPost.Rejected = operationSubmit == "Reject" ? true : false;
                findPost.Published = operationSubmit == "Publish" ? true : false;
                findPost.DatePublished = System.DateTime.Now;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new DAL.Models.TestContext())
            {
                var findPost = db.Posts.Find(id);
                db.Posts.Remove(findPost);
                db.SaveChanges();
            }
        }
    }
}


