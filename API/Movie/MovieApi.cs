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


    public async Task<dbM> PopulateMovie(dbM movie, M apiM)
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
        var posterUrl = apiM.PosterPath;
        var posterType = apiM.PosterPath.Substring(apiM.PosterPath.LastIndexOf('.')+1);
        Poster poster = new Poster();
        poster.Movie = movie;
        poster.MovieId = movie.Id;
        poster.ContentType = posterType;
        poster.Data = await GetImageAsBase64Url("https://image.tmdb.org/t/p/original"+posterUrl);
        movie.Poster = poster;
        foreach (var apiB in apiM.Images.Backdrops.Count() >= 8 ? apiM.Images.Backdrops.GetRange(0, 8) : apiM.Images.Backdrops) 
        {
            var backdropUrl = apiB.FilePath;
            var backdropId = backdropUrl.Substring(backdropUrl.LastIndexOf('/')+1, backdropUrl.LastIndexOf('.')-1);
            var backdropType = backdropUrl.Substring(backdropUrl.LastIndexOf('.')+1);
            Backdrop backdrop = new Backdrop();
            backdrop.Id = backdropId;
            backdrop.Movie = movie;
            backdrop.ContentType = backdropType;
            backdrop.Data = await GetImageAsBase64Url("https://image.tmdb.org/t/p/w1280"+backdropUrl);
            movie.Backdrops.Add(backdrop);
        }
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