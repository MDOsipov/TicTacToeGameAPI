using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using CustomExceptions;
using Entities;
using Entities.DataTransferObjects;
using AutoMapper;

namespace TicTacToeGameWebService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameLogicController : ControllerBase
    {
        private readonly IGameLogicService _gameLogicService;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public GameLogicController(IGameLogicService gameLogicService, ILoggerManager logger, IMapper mapper)
        {
            _gameLogicService = gameLogicService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("CreateNewGame")]
        public async Task<IActionResult> CreateNewGame([FromBody] ParticipantsNames participantsNames)
        {
            _logger.LogDebug($"CreateNewGame method started with participantsNames: {JsonSerializer.Serialize(participantsNames)}");

            try
            {
                Game result = await _gameLogicService.CreateNewGame(participantsNames.CrossesPlayerName, participantsNames.NoughtPlayerName);

                GameDto resultMapped = _mapper.Map<GameDto>(result);    
                _logger.LogInfo("Created. New game is created");
                return CreatedAtRoute("GameById", new { gameId = result.Id }, resultMapped);                
            }
            catch (CustomException ex)
            {
                _logger.LogInfo($"Bad request. {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal server error. Something went wrong inside CreateNewGame action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("StopTheGame")]
        public async Task<IActionResult> StopGameExplicitly()
        {
            _logger.LogDebug($"StopGameExplicitly method started");

            try
            {
                var stoppedGame = await _gameLogicService.StopGameExplicitly();

                GameDto resultMapped = _mapper.Map<GameDto>(stoppedGame);
                _logger.LogInfo("Ok. Currently running game is stopped");
                return Ok(resultMapped);
            }
            catch (NoRunningGamesExistException ex)
            {
                _logger.LogInfo($"Not found. {ex.Message}");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal server error. Something went wrong inside StopGameExplicitly action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("MakeAMove")]
        public async Task<IActionResult> MakeAMove([FromBody] MoveInfo moveInfo)
        {
            _logger.LogDebug($"MakeAMove method started with parameter MoveInfo: {JsonSerializer.Serialize(moveInfo)}");

            if (moveInfo is null)
            {
                _logger.LogInfo("Bad request. Object MoveInfo sent from client is null");
                return BadRequest("Object MoveInfo is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogInfo("Bad request. Object MoveInfo sent from client is not valid");
                return BadRequest("Object MoveInfo is not valid");
            }

            try
            {
                Point newPoint = await _gameLogicService.MakeAMove(moveInfo.GameSideId, moveInfo.X, moveInfo.Y);
                string side = (int)Enums.GameSide.Crosses == moveInfo.GameSideId ? "cross" : "nought";

                PointDto newPointMapped = _mapper.Map<PointDto>(newPoint);
                _logger.LogInfo($"Created. New {side} point is created");
                return CreatedAtRoute("PointById", new { pointId = newPoint.Id }, newPointMapped);
            }
            catch (NoRunningGamesExistException ex)
            {
                _logger.LogInfo($"Not found. {ex.Message}");
                return NotFound(ex.Message);
            }
            catch (CustomException ex)
            {
                _logger.LogInfo($"Bad request. {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal server error. Something went wrong inside MakeAMove action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("CheckForGameover")]
        public async Task<IActionResult> CheckForGameover()
        {
            _logger.LogDebug($"CheckForGameover method started");

            try
            {
                Game? game = await _gameLogicService.CheckForGameover();

                if (game is null)
                {
                    _logger.LogInfo($"No content. Nobody wins yet");
                    return NoContent();
                }

                string gameWinner = game.WinnerPlayer == game.CrossesPlayer ? "Crosses" : "Noughts";
                _logger.LogInfo($"Ok. {gameWinner} has won");

                GameDto resultMapped = _mapper.Map<GameDto>(game);
                return Ok(resultMapped);
            }
            catch (NoRunningGamesExistException ex)
            {
                _logger.LogInfo($"Not found. {ex.Message}");
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal server error. Something went wrong inside CreateNewGame action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
