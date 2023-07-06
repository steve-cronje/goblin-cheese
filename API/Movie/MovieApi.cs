using TMDbLib.Objects.Movies;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;
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
        // movie.Budget = apiM.Budget;
        // movie.Revenue = apiM.Revenue;
        // movie.Runtime = apiM.Runtime;
        if (apiM.Budget > 0) movie.Budget = (double) apiM.Budget;
        if (apiM.Revenue > 0) movie.Revenue = (double) apiM.Revenue;
        if (apiM.Runtime > 0) movie.Runtime = (double) apiM.Runtime / 60;
        
        movie.Title = apiM.Title;
        movie.DateAdded = DateTime.UtcNow;
        return movie;
    }

    public async Task<dbM> PopulateMovieBackdrops(dbM movie, M apiM)
    {

        foreach (var apiB in apiM.Images.Backdrops.Count() >= 8 ? apiM.Images.Backdrops.GetRange(apiM.Images.Backdrops.Count()-8, 8) : apiM.Images.Backdrops) 
        {
            var backdropUrl = apiB.FilePath;
            var backdropId = backdropUrl.Substring(backdropUrl.LastIndexOf('/')+1, backdropUrl.LastIndexOf('.')-1);
            var backdropType = backdropUrl.Substring(backdropUrl.LastIndexOf('.')+1);
            Backdrop backdrop = new Backdrop();
            backdrop.Id = backdropId;
            backdrop.Data = await GetImageAsBase64Url("https://image.tmdb.org/t/p/w1280"+backdropUrl);
            backdrop.ContentType = backdropType;
            backdrop.Movie = movie;
            movie.Backdrops.Add(backdrop);
        }
        return movie;
    }

    public async Task<dbM> PopulatePoster(dbM movie, M apiM)
    {
        var posterUrl = apiM.PosterPath;
        var posterId = posterUrl.Substring(posterUrl.LastIndexOf('/')+1, posterUrl.LastIndexOf('.')-1);
        var posterType = apiM.PosterPath.Substring(apiM.PosterPath.LastIndexOf('.')+1);
        Poster poster = new Poster();
        poster.Id = posterId;
        poster.ContentType = posterType;
        poster.Data = await GetImageAsBase64Url("https://image.tmdb.org/t/p/original"+posterUrl);
        poster.Movie = movie;
        movie.Poster = poster;
        return movie;
    }


    public async Task<SearchContainer<SearchMovie>> SearchForMovieRequest(string searchQuery)
    {
        return await _client.SearchMovieAsync(searchQuery);
    }

    public async static Task<byte[]> GetImageAsBase64Url(string url)
    {   
        using (var client = new HttpClient())
        {
            return await client.GetByteArrayAsync(url);
        }
    }


}