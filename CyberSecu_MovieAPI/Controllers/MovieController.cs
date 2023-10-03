using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI_DAL.Models;
using MovieAPI_DAL.Repos;

namespace CyberSecu_MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_movieService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_movieService.GetById(id));
        }

        [Authorize("Admin")]
        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            _movieService.CreateMovie(movie);
            return Ok();
        }

        [HttpGet("byGenre/{genreid}")]
        public IActionResult ByGenre(int genreid) { 
            return Ok(_movieService.GetByGenreId(genreid));
        }

        [HttpGet("byRealisator/{realid}")]
        public IActionResult ByReal(int realid)
        {
            return Ok(_movieService.GetByRealId(realid));
        }
        [HttpGet("byScenarist/{scenid}")]
        public IActionResult ByScen(int scenid)
        {
            return Ok(_movieService.GetByScenaristId(scenid));
        }

        [HttpGet("byActor/{actorid}")]
        public IActionResult GetByActor(int actorid)
        {
            return Ok(_movieService.GetByActorId(actorid));
        }

        
    }
}
