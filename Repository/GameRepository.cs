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
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(TicTacToeGameContext context)
            :base(context)
        {
            
        }

        public void AddGame(Game game)
        {
            Create(game);
        }

        public async Task<bool> AreThereRunningGames()
        {
            return await FindAll().AnyAsync(g => g.GameStatusId.Equals((int)Enums.GameStatus.Running));
        }

        public void DeleteGame(Game game)
        {
            Delete(game);
        }

        public async Task<IEnumerable<Game>> GetFinishedGames()
        {
            return await FindByCondition(g => g.GameStatusId.Equals((int)Enums.GameStatus.Finished)).ToListAsync();
        }

        public async Task<Game> GetRunningGame()
        {
            return await FindByCondition(g => g.GameStatusId.Equals((int)Enums.GameStatus.Running))
                .Include(g => g.CrossesPlayer)
                .Include(g => g.NoughtsPlayer)
                .Include(g => g.Points)
                .Include(g => g.GameStatus)
                .FirstOrDefaultAsync();
        }

        public void UpdateGame(Game game)
        {
            Update(game);
        }
    }
}
