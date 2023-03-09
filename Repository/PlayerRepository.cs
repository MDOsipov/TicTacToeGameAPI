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
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(TicTacToeGameContext context)
            :base(context)
        {

        }

        public void AddPlayer(Player player)
        {
            Create(player);
        }

        public void DeletePlayer(Player player)
        {
            Delete(player);
        }

        public async Task<Player> GetPlayerById(int playerId)
        {
            return await FindByCondition(p => p.Id.Equals(playerId)).FirstOrDefaultAsync();    
        }

        public async Task<IEnumerable<Player>> GetPlayers()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<bool> PlayerExists(int playerId)
        {
            return await FindByCondition(p => p.Id.Equals(playerId)).AnyAsync();
        }

        public void UpdatePlayer(Player player)
        {
            Update(player);
        }
    }
}
