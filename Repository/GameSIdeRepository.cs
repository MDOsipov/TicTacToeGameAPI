using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GameSideRepository : RepositoryBase<GameSide>, IGameSideRepository
    {
        public GameSideRepository(TicTacToeGameContext context)
            : base(context)
        {

        }

        public async Task<GameSide> GetGameSideById(int gameSideId)
        {
            return await FindByCondition(gs => gs.Id.Equals(gameSideId)).FirstOrDefaultAsync();
        }
    }
}
