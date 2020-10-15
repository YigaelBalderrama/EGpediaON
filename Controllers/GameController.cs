using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EGpediaON.Models;
using EGpediaON.Services;
using EGpediaON.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

namespace EGpediaON.Controllers
{
   
    [Route ("api/[controller]")]
    public class GameController:Controller
    {
        private IGameService _gameService;
        public GameController(IGameService gameService)
        {
            this._gameService = gameService;
        }
        [HttpGet]
        public ActionResult <IEnumerable<GameModel>> getGames(string orderBy="id")
        {   
            try
            {
                return Ok(_gameService.GetGames(orderBy));
            }
            catch (BadRequestOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpGet("{gameId:int}")]
        public ActionResult <GameModel> myGame(int gameId)
        {
            try
            {
                return Ok(_gameService.myGame(gameId));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpPost]
        public ActionResult<GameModel> CreateGame([FromBody] GameModel Game)
        {
            try
            {
                var url = HttpContext.Request.Host;
                var newGame = _gameService.CreateGame(Game);
                return Created($"{url}/api/Game/{newGame.Id}",newGame);
            }
            catch (Exception ex)
            { 
               return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpDelete("{gameId:int}")]
        public ActionResult <DeleteModel> DeleteGame(int gameId)
        {
            try
            {
                return Ok(_gameService.DeleteGame(gameId));
            }
            catch(BadRequestOperationException ex)
            {
                return BadRequest(new DeleteModel()
                {
                    isSuccess = false,
                    Message = ex.Message
                }) ;
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }

        }
        [HttpPut]
        public ActionResult<GameModel> UpdateGame()
        {
            return null;
        }
    }
}
