using IGDB;
using IGDB.Models;

namespace goblin_cheese.API {

    public class GameApi {

        IGDBClient igdb;

        public GameApi(string clientId, string clientSecret)
        {
            igdb = new IGDBClient(clientId, clientSecret);
        }

        public async Task<Game> GetGame(int gameId) {
            var games = await igdb.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: $"fields name,summary,cover.image_id,genres.name,first_release_date,screenshots.*; where id = {gameId};");
            var game = games.First();

            return game;
        }

    }
}