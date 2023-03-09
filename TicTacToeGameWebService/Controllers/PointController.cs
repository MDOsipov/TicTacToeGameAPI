using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Contracts;

namespace TicTacToeGameWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public PointController(IRepositoryWrapper wrapper)
        {
            _repository = wrapper;
        }

        [HttpGet("{pointId}", Name = "PointById")]
        public async Task<Point> GetPointById(int pointId)
        {
            return await _repository.Point.GetPointById(pointId);
        }
    }
}
