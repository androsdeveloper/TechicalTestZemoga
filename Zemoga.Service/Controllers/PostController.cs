using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zemoga.Business.Interfaces;
using Zemoga.DTO;

namespace Zemoga.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        IPost _post;

        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger, IPost post)
        {
            _logger = logger;
            _post = post;
        }

        //<summary>
        //This method get the Posts pending of approval
        //</summary>

        [HttpGet]
        public ActionResult<List<Post>> Get()
        {
            var result =_post.GetByPendingApproval();

            if(result == null)
            {
                return NotFound("No records found");
            }

            return Ok(result);
        }

        //<summary>
        //This method recive action (Reject or Publish)
        //</summary>
        //<param name="action"> (Reject or Publish) </parameter>
        //<parameter name="action">Post Object</parameter>

        [HttpPost("{action}")]
        public ActionResult Post(string action, Post post)
        {
            if (string.IsNullOrEmpty(action) && action != "Publish" && action != "Reject") {
                return BadRequest("Action parmeter is incorrect");
            }

            var result = _post.GetDetailsById(post.IdPost);

            if (result == null)
            {
                return NotFound("IdPost doesn´t exist");
            }
            _post.Edit(post, action);

            return Ok();
        }
    }
}