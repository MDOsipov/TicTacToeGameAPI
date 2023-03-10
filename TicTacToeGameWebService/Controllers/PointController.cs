using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Contracts;
using Entities.DataTransferObjects;
using static Entities.Enums;
using AutoMapper;

namespace TicTacToeGameWebService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PointController(IRepositoryWrapper wrapper, ILoggerManager logger, IMapper mapper)
        {
            _repository = wrapper;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{pointId}", Name = "PointById")]
        public async Task<IActionResult> GetPointById(int pointId)
        {
            _logger.LogDebug($"GetPointById method started with pointId: {pointId}");

            try
            {
                if (!await _repository.Point.PointExists(pointId))
                {
                    _logger.LogInfo($"Not found. Point with id of {pointId} doesn't exist");
                    return NotFound("Point with this id doesn't exist");
                }

                Point point = await _repository.Point.GetPointById(pointId);
                PointDto pointMapped = _mapper.Map<PointDto>(point);

                _logger.LogInfo("Ok. Point is received");
                return Ok(pointMapped);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Internal server error. Something went wrong inside GetPointById action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }

        }
    }
}
