using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieReview.Models;

class Actor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
    public int ActorId{ get; set; }

    [Required]
    [MaxLength(100)]
    [Column("first_name")]
    public string? FirstName{get; set;}

    [Required]
    [MaxLength(200)]
    [Column("last_name")]
    public string? LastName{get; set;}

    [Required]
    [Column("birth_day")]
    public DateOnly BirthDay {get;set;} = DateOnly.FromDateTime(DateTime.Now);

    public List<Film> Films { get; set; } = new List<Film>();
}