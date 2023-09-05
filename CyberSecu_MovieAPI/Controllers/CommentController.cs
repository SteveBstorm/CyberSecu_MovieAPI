using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI_DAL.Models;
using MovieAPI_DAL.Repos;

namespace CyberSecu_MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("byMovie/{movieid}")]
        public IActionResult Get(int movieid)
        {
            return Ok(_commentService.GetComments(movieid));
        }

        [HttpPost]
        public IActionResult post(Comment c)
        {
            _commentService.AddComment(c);
            return Ok();
        }
    }
}
