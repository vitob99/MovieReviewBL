using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReview.Models;

[Table("film")]
public class Film
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

    [Required]
    [Column("poster_link")]
    public string? poster_link{ get; set; }


    public List<Actor> Actors { get; set; } = new List<Actor>();
}