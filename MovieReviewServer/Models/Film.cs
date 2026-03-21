using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MovieReview.Models;

[Table("film")]
class Film
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
    public int FilmId{ get; set; }

    [Required]
    [MaxLength(100)]
    [Column("title")]
    public string? Title{ get; set; }

    [Required]
    [Column("year")]
    public int Year{ get; set; }

    [Required]
    [Column("genre")]
    public string? Genre{ get; set; }

    public List<Actor> Actors { get; set; } = new List<Actor>();
}