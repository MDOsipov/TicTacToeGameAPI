using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IPlayerRepository
    {
        Task<bool> PlayerExists(int playerId);
        Task<IEnumerable<Player>> GetPlayers();
        Task<Player> GetPlayerById(int playerId);
        void AddPlayer(Player player);
        void UpdatePlayer(Player player);
        void DeletePlayer(Player player);
    }
}
