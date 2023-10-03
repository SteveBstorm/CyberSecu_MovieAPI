using CyberSecu_MovieAPI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPI_DAL.Models;
using MovieAPI_DAL.Repos;

namespace CyberSecu_MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.GetAll());
        }

       // [Authorize("AdminPolicy")]
        [HttpPost]
        public IActionResult Post(newPerson person)
        {
            _personService.CreatePerson(
                new Person
                {
                    Firstname = person.Firstname,
                    Id = 0,
                    Lastname = person.Lastname,
                    ImageUrl = person.ImageUrl
                });
            return Ok();
        }

        [HttpGet("casting/{movieid}")]
        public IActionResult GetCasting(int movieid) 
        {
            return Ok(_personService.GetRoleByMovieId(movieid));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            return Ok(_personService.GetById(id));
        }

        //[Authorize("AdminPolicy")]
        [HttpPost("setActor")]
        public IActionResult SetActor(PersonRole actor)
        {
            _personService.SetAsActor(actor.IdPerson, actor.IdMovie, actor.Role);
            return Ok();
        }
    }
}
