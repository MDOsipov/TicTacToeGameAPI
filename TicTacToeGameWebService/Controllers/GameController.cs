using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using AutoMapper;
using Entities.DataTransferObjects;

namespace TicTacToeGameWebService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public GameController(IRepositoryWrapper wrapper, ILoggerManager logger, IMapper mapper)
        {
            _repository = wrapper;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{gameId}", Name = "GameById")]
        public async Task<IActionResult> GetGameById(int gameId)
        {
            _logger.LogDebug($"GetGameById method started with gameId: {gameId}");

            try
            {
                if (!await _repository.Game.GameExists(gameId))
                {
                    _logger.LogInfo($"Not found. Game with game id of {gameId} doesn't exist");
                    return NotFound("Game with this id doesn't exist");
                }

                Game game = await _repository.Game.GetGameById(gameId);
                GameDto gameMapped = _mapper.Map<GameDto>(game);

                _logger.LogInfo("Ok. Game is received");
                return Ok(gameMapped);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal server error. Something went wrong inside GetGameById action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

    }
}
