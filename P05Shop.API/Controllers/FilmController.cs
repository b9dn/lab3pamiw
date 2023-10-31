using Microsoft.AspNetCore.Mvc;
using P04WeatherForecastAPI.Client.Models;
using P06.Shared;
using P06.Shared.Services.FilmService;
using P06.Shared.Films;

namespace P05Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;

        public FilmController(IFilmService FilmService)
        {
            _filmService = FilmService;
        }

        [HttpGet()]
        public async Task<ActionResult<ServiceResponse<List<Film>>>> GetFilms()
        {
            var result = await _filmService.ReadFilmAsync();

            if (result.Success)
                return Ok(result);
            else
                return  StatusCode(result.CodeError, $"{result.Message}");
        }

        [HttpPost("CreateFilm")] 
        public async Task<ActionResult<ServiceResponse<List<Film>>>> AddFilm([FromBody] Film film)
        {
            var result = await _filmService.CreateFilmAsync(film);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(result.CodeError, $"{result.Message}");
        }
        [HttpDelete("DeleteFilm/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Film>>>> DeleteFilm([FromRoute] int id)
        {
            var result = await _filmService.DeleteFilmAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(result.CodeError, $"{result.Message}");
        }

        [HttpPut("UpdateFilm/{id}")]
        public async Task<ActionResult<ServiceResponse<List<Film>>>> UpdateFilm([FromRoute] int id, [FromBody] Film film)
        {
            var result = await _filmService.UpdateFilmAsync(id, film);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(result.CodeError, $"{result.Message}");
        }


    }
}
