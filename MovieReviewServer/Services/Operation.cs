
using MovieReview.Data;
using MovieReview.Models;


static class Operation
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
}