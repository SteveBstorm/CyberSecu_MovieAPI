using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI_DAL.Repos;

namespace CyberSecu_MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_genreService.GetAll());
        }
        //[Authorize("Admin")]

        [HttpPost]
        public IActionResult Create(string genre)
        {
            _genreService.CreateGenre(genre);
            return Ok();
        }
    }
}
