using MovieReview.Data;
using MovieReview.Models;

namespace MovieReview.Services;

static class Operation //implementa le operazione utili a ottenere informazioni dal database
{
    public static int GetUserCount(MovieReviewDbContext db)
    {
        return db.Users.Count();
    }

    public static int GetFilmCount(MovieReviewDbContext db)
    {
        return db.Films.Count();
    }

    public static int GetActorCount(MovieReviewDbContext db)
    {
        return db.Actors.Count();
    }

    public static int GetReviewCount(MovieReviewDbContext db)
    {
        return db.Reviews.Count();
    }

    public static void RegisterUser(MovieReviewDbContext db, User user)
    {
        db.Users.Add(user);
        db.SaveChanges();
    }

    public static List<Film> GetFilms(MovieReviewDbContext db)
    {
        return db.Films.ToList();
    }

    public static float GetAvarageRating(MovieReviewDbContext db, int film_id)
    {
        var filmReviews = db.Reviews.Where(r => r.FilmId == film_id);
        if (!filmReviews.Any())
        {
            return 0f;
        }

        return (float)filmReviews.Average(r => r.Rating);
    }

    public static void PostReview(MovieReviewDbContext db, Review review)
    {
        var existingReview = db.Reviews.FirstOrDefault(r => r.UserId == review.UserId && r.FilmId == review.FilmId);

        if (existingReview != null)
        {
            existingReview.Rating = review.Rating;
            existingReview.ShortReview = review.ShortReview;
        }
        else
        {
        
            db.Reviews.Add(review);
        }
        db.SaveChanges();
    }
}