using Microsoft.EntityFrameworkCore;
using MovieReview.Models;
class MovieReviewDbContext : DbContext
{
    public MovieReviewDbContext(DbContextOptions<MovieReviewDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Actor> Actors { get; set; } = null!;
    public DbSet<Film> Films { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;
}