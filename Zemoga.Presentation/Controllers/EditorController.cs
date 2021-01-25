using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zemoga.Business.Interfaces;

namespace Zemoga.Presentation.Controllers
{
    [Authorize(Roles = "Editor")]
    public class EditorController : Controller
    {
        IPost _post;
        public EditorController(IPost post)
        {
            _post = post;
        }
        // GET: Posts
        public ActionResult Index()
        {
            return View(_post.GetByPendingApproval());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int id)
        {
            var result = _post.GetDetailsById(id);
            return View(result[0]);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTO.Post postInfo)
        {
            try
            {
                _post.Save(postInfo);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _post.GetDetailsById(id);
            return View(result[0]);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DTO.Post post, string submit)
        {
            try
            {
                _post.Edit(post, submit);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View();
            }
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _post.GetDetailsById(id);
            return View(result[0]);
        }

        // POST: Posts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DTO.Post post)
        {
            try
            {
                _post.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}