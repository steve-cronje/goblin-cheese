using TMDbLib.Objects.Movies;
using goblin_cheese.Models.Movie;
using M = TMDbLib.Objects.Movies.Movie;
using dbM = goblin_cheese.Models.Movie.Movie;
using TMDbLib.Client;

namespace goblin_cheese.API.Movie;

public class MovieApi 
{
    private readonly TMDbClient _client;
    public MovieApi(TMDbClient client)
    {
        _client = client;
    }

    public async void LogMovieRequestAsync(int id)
    {
        M movie = await _client.GetMovieAsync(id);
    }

    public async Task<M> GetMovieRequestAsync(int movieId)
    {
        M apiM = await _client.GetMovieAsync(movieId, MovieMethods.Images);
        return apiM;
    }


    public dbM PopulateMovie(dbM movie, M apiM)
    {
        movie.Id = apiM.Id;
        movie.Overview = apiM.Overview;
        if (apiM.ReleaseDate != null) 
        {
            movie.ReleaseDate = new DateOnly
            (
                apiM.ReleaseDate.Value.Year, 
                apiM.ReleaseDate.Value.Month, 
                apiM.ReleaseDate.Value.Day
            );
        }
        movie.Budget = apiM.Budget;
        movie.Revenue = apiM.Revenue;
        movie.Runtime = apiM.Runtime;
        movie.Title = apiM.Title;
        return movie;
    }

    public async static Task<byte[]> GetImageAsBase64Url(string url)
    {   
        using (var client = new HttpClient())
        {
            return await client.GetByteArrayAsync(url);
        }
    }
}