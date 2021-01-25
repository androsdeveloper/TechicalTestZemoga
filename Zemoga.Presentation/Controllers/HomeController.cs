using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zemoga.Business.Interfaces;
using Zemoga.Presentation.Models;

namespace Zemoga.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IPost _post;
        IComment _comment;
        public HomeController(ILogger<HomeController> logger, IComment comment, IPost post)
        {
            _logger = logger;
            _post = new Business.Posts();
            _comment = comment;

        }

        public IActionResult Index()
        {
            var lstOPost = _post.GetAllPost();

            return View(lstOPost);
        }

        // GET: Writer/Home/5
        public ActionResult Details(int id)
        {
            var post = _post.GetDetailsById(id);

            var result = _comment.GetCommentByIdPost(post[0]);

            return View(result[0]);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: Writer/Create
        public ActionResult Create(int idPost)
        {
            Zemoga.DTO.Comment comment = new Zemoga.DTO.Comment();
            comment.IdPost = idPost;
            return View(comment);
        }

        // POST: Writer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTO.Comment commentInfo)
        {
            try
            {
                _comment.Save(commentInfo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("Index");
        }
    }
}
