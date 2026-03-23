using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReview.Models;

class Review
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int FilmId { get; set; }
    public Film Film { get; set; } = null!;

    [Required]
    [Column("rating")]
    public int Rating {get; set;}

    [Column("short_review")]
    [MaxLength(200)]
    public string? ShortReview {get; set;}
}