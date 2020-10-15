using EGpediaON.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGpediaON.Services
{
    public interface IGameService
    {
        IEnumerable<GameModel> GetGames(string Orderby);
        GameModel myGame(int gameId);
        GameModel CreateGame(GameModel game);
        DeleteModel DeleteGame(int gameId);
        GameModel UpdateGame(int gameId,GameModel gameModel);
    }
}
