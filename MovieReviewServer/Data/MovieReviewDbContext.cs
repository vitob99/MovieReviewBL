using Microsoft.EntityFrameworkCore;
using MovieReview.Models;

namespace MovieReview.Data;

class MovieReviewDbContext : DbContext
{
    public MovieReviewDbContext(DbContextOptions<MovieReviewDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Actor> Actors { get; set; } = null!;
    public DbSet<Film> Films { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Review>().HasKey(r => new { r.UserId, r.FilmId });
    }
}