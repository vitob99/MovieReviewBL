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
        bool name_email_exists = db.Users.Any(u => u.Username == user.Username || u.Email == user.Email);
        if (name_email_exists)
        {
            return BadRequest("Errore: username o email già utilizzati!");
        }

        Operation.RegisterUser(db, user);
        log_manager.AddLog("REGISTRAZIONE", $"L'utente '{user.Username}' si e' appena registrato!");
        return Ok("Utente creato");
    }

    
    [HttpPost("login")] 
    public async Task<ActionResult<User>> Login(LoginRequest request) //usare una variabile LoginRequest mi evita di mostrare in chiaro username e password
    {
        var user = db.Users.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password); 

        if (user == null)
        {
            return Unauthorized("Credenziali non valide!"); 
        }
        log_manager.AddLog("LOGIN", $"L'utente '{user.Username}' ha effettuato l'accesso!");
        return Ok(user);
    } 
}

public class LoginRequest {
    public string? Username { get; set; }
    public string? Password { get; set; }
}