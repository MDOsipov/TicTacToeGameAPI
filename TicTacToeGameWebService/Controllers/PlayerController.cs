using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace TicTacToeGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;

        public PlayerController(IRepositoryWrapper wrapper)
        {
            _repository = wrapper;
        }

    }
}
