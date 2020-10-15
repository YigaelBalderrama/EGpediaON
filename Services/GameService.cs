using EGpediaON.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EGpediaON.Exceptions;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace EGpediaON.Services
{
    public class GameService:IGameService
    {
        private List<GameModel> games = new List<GameModel>()
        {
            new GameModel() {Id=1,Name="dota"},
            new GameModel() {Id=2,Name="lol"}
        };
        private HashSet<string> AllowedOrderByParameters = new HashSet<string>()
        {
            "id","numberofplayers","company","lauchdate","name"
        };

        public GameModel CreateGame(GameModel game)
        {
            int newId;
            if (games.Count==0)
            {
                newId = 1;
            }
            else
            {
                newId = games.OrderByDescending(c => c.Id).FirstOrDefault().Id + 1;
            }
            game.Id = newId;
            games.Add(game);
            return game;
        }

        public DeleteModel DeleteGame(int gameId)
        {
            var Toremove = games.FirstOrDefault(g => g.Id == gameId);
            if (Toremove==null)
            {
                throw new BadRequestOperationException($"The game with id {gameId} not exits");
            }
            var result = games.Remove(Toremove);
            return new DeleteModel()
            {
                isSuccess = true,
                Message = "The game was removed"
            };
        }

        public IEnumerable <GameModel> GetGames(string orderBy)
        {
            if (!AllowedOrderByParameters.Contains(orderBy.ToLower()))
            {
                throw new BadRequestOperationException($"the field :{orderBy} is not supported, try again with {string.Join(",",AllowedOrderByParameters)}");
            }
            switch (orderBy)
            {
                case "id":
                    return games.OrderBy(g => g.Id);
                case "numberofplayers":
                    return games.OrderBy(g => g.Numberofplayers);
                case "compani":
                    return games.OrderBy(g => g.Company);
                case "launchdate":
                    return games.OrderBy(g => g.Lauchdate);
                case "name":
                    return games.OrderBy(g => g.Name);
                default:
                    break;
            }
            return games;
        }
        public GameModel myGame(int gameId)
        {
            return games.FirstOrDefault(g=>g.Id==gameId);
        }

        public GameModel UpdateGame(int gameId, GameModel gameModel)
        {
          
        }
    }
}
