using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MovieReview.Data;
using Microsoft.Extensions.Logging;

namespace MovieReview.Services;

static class Server //gestisce l'inizializzazione, l'avvio e l'arresto del server rest ASP.net
{
    public static WebApplication Start(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Logging.ClearProviders();
        
        string connectionString = "server=localhost;port=3306;database=movie_review_db;user=root;password=Milan1997."; //! non dovrebbe essere hard coded
        builder.Services.AddDbContext<MovieReviewDbContext>(options => options.UseMySql(connectionString!, ServerVersion.AutoDetect(connectionString)));
        builder.Services.AddSingleton(LogManager.Instance);

        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<MovieReviewDbContext>();

            try
            {
                db.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la migrazione: {ex.Message}");

            }
        }

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.MapControllers();
        app.StartAsync();
        return app;
    }

    public static void Stop(WebApplication app)
    {
       app.StopAsync();
    }
}