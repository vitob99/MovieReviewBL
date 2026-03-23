using Microsoft.AspNetCore.Mvc;
using MovieReview.Data;
using MovieReview.Models;
using Microsoft.EntityFrameworkCore;

namespace UserService.Controllers;


[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly MovieReviewDbContext db;
    private readonly LogManager log_manager;

    public UserController(MovieReviewDbContext db, LogManager log_manager)
    {
        this.db = db;
        this.log_manager = log_manager;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> CreateUser([FromBody] User user)
    {
        Operation.RegisterUser(db, user);
        await db.SaveChangesAsync();

        log_manager.AddLog("REGISTRAZIONE", $"L'utente {user.Username} si e' registrato!");
        
        return CreatedAtAction(nameof(CreateUser), new { id = user.UserId }, user);
    }

    
    [HttpPost("login")] 
    public async Task<ActionResult<User>> Login(string username, string password)
    {
        var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user == null)
        {
            return Unauthorized("Credenziali non valide, controlla il tuo username e/o la tua password!"); 
        }


        log_manager.AddLog("LOGIN", $"L'utente {user.Username} ha effettuato l'accesso!");
        return Ok(user); 
    }
}