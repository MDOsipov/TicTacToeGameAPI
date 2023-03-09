using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;

namespace TicTacToeGameWebService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        public GameController(IRepositoryWrapper wrapper)
        {
            _repository = wrapper;  
        }
        [HttpGet("{gameId}", Name = "GameById")]
        public async Task<Game> GetGameById(int gameId)
        {
            return await _repository.Game.GetRunningGame();
        }

    }
}
