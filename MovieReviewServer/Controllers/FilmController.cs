using Microsoft.AspNetCore.Mvc;
using MovieReview.Data;
using MovieReview.Models;
using MovieReview.Services;

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

    [HttpGet("average/{film_id}")]
    public async Task<ActionResult<Film>> GetAverageRating(int film_id)
    {
        return Ok(Operation.GetAvarageRating(db, film_id));
    }

    [HttpPost("post_review")]
    public async Task<ActionResult<Review>> PostReview([FromBody] Review review)
    {
        Operation.PostReview(db, review);
        return Ok();
    }
}