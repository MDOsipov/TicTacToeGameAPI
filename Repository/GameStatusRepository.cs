using Contracts;
using Entities.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class GameStatusRepository : RepositoryBase<GameStatus>, IGameStatusRepository
    {
        public GameStatusRepository(TicTacToeGameContext context)
            :base(context)
        {

        }

        public async Task<GameStatus> GetGameStatusById(int gameStatusId)
        {
            return await FindByCondition(gs => gs.Id.Equals(gameStatusId)).FirstOrDefaultAsync();
        }   
    }
}
