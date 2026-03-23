using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReview.Models;

[Table("users")]
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
    public int UserId{ get; set; }

    [Required]
    [MaxLength(100)]
    [Column("username")]
    public string? Username{get; set;}

    [Required]
    [MaxLength(200)]
    [Column("email")]
    public string? Email{get; set;}

    [Required]
    [MaxLength(50)]
    [Column("password")]
    public string? Password {get;set;}

    [Required]
    [Column("registration_date")]
    public DateOnly RegistrationDate {get;set;} = DateOnly.FromDateTime(DateTime.Now);

    public List<Review> user_reviews = new List<Review>();
}