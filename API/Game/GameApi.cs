using IGDB;
using ApiGame = IGDB.Models.Game;

namespace goblin_cheese.API.Game {

    public class GameApi {

        private readonly IGDBClient _igdb;

        public GameApi(IGDBClient igdb)
        {
            _igdb = igdb;
        }

        public async Task<ApiGame> GetGame(int gameId) {
            var games = await _igdb.QueryAsync<ApiGame>(IGDBClient.Endpoints.Games, query: $"fields name,summary,cover.image_id,genres.name,first_release_date,screenshots.*; where id = {gameId};");
            var game = games.First();

            return game;
        }

    }
}