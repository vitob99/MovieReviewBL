using Microsoft.AspNetCore.Mvc;
using MovieReview.Data;
using MovieReview.Models;

namespace UserService.Controllers;

[ApiController]
[Route("film")]
public class FilmController: ControllerBase
{
    private readonly MovieReviewDbContext db;
    
    public FilmController(MovieReviewDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
    public async Task<ActionResult<Film>> GetFilmList()
    {
        return Ok(Operation.GetFilms(db));
    }
}