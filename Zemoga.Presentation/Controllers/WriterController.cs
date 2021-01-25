using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zemoga.Business.Interfaces;

namespace Zemoga.Presentation.Controllers
{
    [Authorize(Roles = "Writer")]
    public class WriterController : Controller
    {
        IPost _post;

        public WriterController()
        {
            _post = new Business.Posts();
        }
        // GET: Writer        
        public ActionResult Index()
        {
            
            return View(_post.GetByRejected());
        }

        // GET: Writer/Details/5
        public ActionResult Details(int id)
        {
            var result = _post.GetDetailsById(id);
            return View(result[0]);
        }

        // GET: Writer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Writer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTO.Post postInfo)
        {
            try
            {
                _post.Save(postInfo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Writer/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _post.GetDetailsById(id);
            return View(result[0]);
        }

        // POST: Writer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DTO.Post post)
        {
            try
            {
                _post.Edit(post);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}